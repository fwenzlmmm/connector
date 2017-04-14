using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIforMySql.Models
{
    public interface IDataAccessProvider
    {
        void AddExtractDefinitionRecord(ExtractDefinitions extractDefinition);
        void UpdateExtractDefinitionRecord(long dataEventRecordId, ExtractDefinitions extractDefinition);
        void DeleteExtractDefinitionRecord(long extractDefinitionId);
        ExtractDefinitions GetExtractDefinitionRecord(long extractDefinitionId);
        List<ExtractDefinitions> GetExtractDefinitionRecords();
    }
}