using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Text.RegularExpressions;

namespace VA.Infrastructure.CrossCutting.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ToVarchar(this ModelBuilder modelBuilder)
        {
            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(p => p.GetProperties())
                .Where(p => p.ClrType == typeof(string)
                        && p.GetColumnType() == null);

            foreach (var property in properties)
            {
                property.SetIsUnicode(false);
            }

            return modelBuilder;
        }

        public static ModelBuilder ToSnakeCaseNames(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName().ToSnakeCase();
                entity.SetTableName(tableName);

                foreach (var property in entity.GetProperties())
                {
                    var storeObjectIdentifier = StoreObjectIdentifier.Table(tableName, null);

                    var columnName = property.GetColumnName(storeObjectIdentifier).ToSnakeCase();

                    property.SetColumnName(columnName);
                }

                foreach (var key in entity.GetKeys())
                {
                    var keyName = key.GetName().ToSnakeCase();
                    key.SetName(keyName);
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    var foreignKeyName = key.GetConstraintName().ToSnakeCase();
                    key.SetConstraintName(foreignKeyName);
                }

                foreach (var index in entity.GetIndexes())
                {
                    var indexName = index.GetDatabaseName().ToSnakeCase();
                    index.SetDatabaseName(indexName);
                }
            }

            return modelBuilder;
        }
        public static ModelBuilder ToDeleteRestrict(this ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            return modelBuilder;
        }

        //UserId -> user_id
        private static string ToSnakeCase(this string name)
            => Regex.Replace(
                name,
                @"([a-z0-9])([A-Z])",
                "$1_$2").ToLower();
    }
}
