using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Phase_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Phase_TypeService : ISpartan_WorkFlow_Phase_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type> _Spartan_WorkFlow_Phase_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Phase_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type> Spartan_WorkFlow_Phase_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Phase_TypeRepository = Spartan_WorkFlow_Phase_TypeRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_WorkFlow_Phase_TypeRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>("sp_SelAllSpartan_WorkFlow_Phase_Type");
        }

        public IList<Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_WorkFlow_Phase_Type_Complete>("sp_SelAllComplete_Spartan_WorkFlow_Phase_Type");
            return data.Select(m => new Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type
            {
                Phase_TypeId = m.Phase_TypeId
                ,Description = m.Description


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_WorkFlow_Phase_Type>("sp_ListSelCount_Spartan_WorkFlow_Phase_Type", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var padreWhere = _dataProvider.GetParameter();
                padreWhere.ParameterName = "Where";
                padreWhere.DbType = DbType.String;

                padreWhere.Value = Where;

                var padreOrderBy = _dataProvider.GetParameter();
                padreOrderBy.ParameterName = "Order";
                padreOrderBy.DbType = DbType.String;
                padreOrderBy.Value = Order;


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Phase_Type>("sp_ListSelAll_Spartan_WorkFlow_Phase_Type", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type
                {
                    Phase_TypeId = m.Spartan_WorkFlow_Phase_Type_Phase_TypeId,
                    Description = m.Spartan_WorkFlow_Phase_Type_Description,

                    //Id = m.Id,
                }).ToList();
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Phase_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Phase_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            var padstartRowIndex = _dataProvider.GetParameter();
            padstartRowIndex.ParameterName = "startRowIndex";
            padstartRowIndex.DbType = DbType.Int32;
            padstartRowIndex.Value = startRowIndex;

            var padmaximumRows = _dataProvider.GetParameter();
            padmaximumRows.ParameterName = "maximumRows";
            padmaximumRows.DbType = DbType.Int32;
            padmaximumRows.Value = maximumRows;

            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var padOrder = _dataProvider.GetParameter();
            padOrder.ParameterName = "Order";
            padOrder.DbType = DbType.String;
            padOrder.Value = Order;

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_WorkFlow_Phase_Type>("sp_ListSelAll_Spartan_WorkFlow_Phase_Type", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_WorkFlow_Phase_TypePagingModel result = null;

            if (data != null)
            {
                result = new Spartan_WorkFlow_Phase_TypePagingModel
                {
                    Spartan_WorkFlow_Phase_Types =
                        data.Select(m => new Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type
                {
                    Phase_TypeId = m.Spartan_WorkFlow_Phase_Type_Phase_TypeId
                    ,Description = m.Spartan_WorkFlow_Phase_Type_Description

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Phase_TypeRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type GetByKey(short Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Phase_TypeId";
            padreKey.DbType = DbType.Int16;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>("sp_GetSpartan_WorkFlow_Phase_Type", padreKey).SingleOrDefault();
        }

        public bool Delete(short Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Phase_TypeId";
                padreKey.DbType = DbType.Int16;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_WorkFlow_Phase_Type>("sp_DelSpartan_WorkFlow_Phase_Type", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result.ToString() == "1";
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public short Insert(Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type entity)
        {
            short rta;
            try
            {

		                var padreDescription = _dataProvider.GetParameter();
                padreDescription.ParameterName = "Description";
                padreDescription.DbType = DbType.String;
                padreDescription.Value = (object)entity.Description ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_WorkFlow_Phase_Type>("sp_InsSpartan_WorkFlow_Phase_Type" 
, padreDescription
).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Phase_TypeId);

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public short Update(Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type entity)
        {
            short rta;
            try
            {

                var paramUpdPhase_TypeId = _dataProvider.GetParameter();
                paramUpdPhase_TypeId.ParameterName = "Phase_TypeId";
                paramUpdPhase_TypeId.DbType = DbType.Int16;
                paramUpdPhase_TypeId.Value = (object)entity.Phase_TypeId ?? DBNull.Value;
                var paramUpdDescription = _dataProvider.GetParameter();
                paramUpdDescription.ParameterName = "Description";
                paramUpdDescription.DbType = DbType.String;
                paramUpdDescription.Value = (object)entity.Description ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_WorkFlow_Phase_Type>("sp_UpdSpartan_WorkFlow_Phase_Type" , paramUpdPhase_TypeId , paramUpdDescription ).FirstOrDefault();

                rta = Convert.ToInt16(empEntity.Phase_TypeId);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }
        #endregion
    }
}
