using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.Utilities;

namespace FASTrack.Model.Concretes
{
    public class InterimAnalysisRespository : IInterimAnalysisRespository
    {
        private ILogService _logService;

        public InterimAnalysisRespository(ILogService logService)
        {
            this._logService = logService;
        }

        public System.Collections.Generic.IEnumerable<InterimAnalysisDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<InterimAnalysisDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public SaveResult Update(InterimAnalysisDto entity)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<SaveResult> UpdateAsync(InterimAnalysisDto entity)
        {
            throw new System.NotImplementedException();
        }

        public SaveResult Add(InterimAnalysisDto entity)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<SaveResult> AddAsync(InterimAnalysisDto entity)
        {
            throw new System.NotImplementedException();
        }

        public SaveResult AddRange(System.Collections.Generic.IEnumerable<InterimAnalysisDto> entities)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<SaveResult> AddRangeAsync(System.Collections.Generic.IEnumerable<InterimAnalysisDto> entities)
        {
            throw new System.NotImplementedException();
        }

        public SaveResult Delete(InterimAnalysisDto entity)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<SaveResult> DeleteAsync(InterimAnalysisDto entity)
        {
            throw new System.NotImplementedException();
        }

        public InterimAnalysisDto Single(int id)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<InterimAnalysisDto> SingleAsync(int id)
        {
            throw new System.NotImplementedException();
        }


        public SaveResult DeleteBy(int Id)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<SaveResult> DeleteByAsync(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
