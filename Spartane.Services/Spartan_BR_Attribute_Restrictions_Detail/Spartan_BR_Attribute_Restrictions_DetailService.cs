﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Attribute_Restrictions_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Attribute_Restrictions_DetailService : ISpartan_BR_Attribute_Restrictions_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail> _Spartan_BR_Attribute_Restrictions_DetailRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Attribute_Restrictions_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail> Spartan_BR_Attribute_Restrictions_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Attribute_Restrictions_DetailRepository = Spartan_BR_Attribute_Restrictions_DetailRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Spartan_BR_Attribute_Restrictions_DetailRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail>("sp_SelAllSpartan_BR_Attribute_Restrictions_Detail");
        }

        public IList<Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSpartan_BR_Attribute_Restrictions_Detail_Complete>("sp_SelAllComplete_Spartan_BR_Attribute_Restrictions_Detail");
            return data.Select(m => new Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail
            {
                RestrictionId = m.RestrictionId
                ,Action = m.Action
                ,Attribute_Type_Spartan_Attribute_Type = new Core.Classes.Spartan_Attribute_Type.Spartan_Attribute_Type() { Attribute_Type_Id = m.Attribute_Type.GetValueOrDefault(), Description = m.Attribute_Type_Description }
                ,Control_Type_Spartan_Attribute_Control_Type = new Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type() { ControlTypeId = m.Control_Type.GetValueOrDefault(), Description = m.Control_Type_Description }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Spartan_BR_Attribute_Restrictions_Detail>("sp_ListSelCount_Spartan_BR_Attribute_Restrictions_Detail", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Attribute_Restrictions_Detail>("sp_ListSelAll_Spartan_BR_Attribute_Restrictions_Detail", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail
                {
                    RestrictionId = m.Spartan_BR_Attribute_Restrictions_Detail_RestrictionId,
                    Action = m.Spartan_BR_Attribute_Restrictions_Detail_Action,
                    Attribute_Type = m.Spartan_BR_Attribute_Restrictions_Detail_Attribute_Type,
                    Control_Type = m.Spartan_BR_Attribute_Restrictions_Detail_Control_Type,

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

        public IList<Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Attribute_Restrictions_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Attribute_Restrictions_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSpartan_BR_Attribute_Restrictions_Detail>("sp_ListSelAll_Spartan_BR_Attribute_Restrictions_Detail", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Spartan_BR_Attribute_Restrictions_DetailPagingModel result = null;

            if (data != null)
            {
                result = new Spartan_BR_Attribute_Restrictions_DetailPagingModel
                {
                    Spartan_BR_Attribute_Restrictions_Details =
                        data.Select(m => new Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail
                {
                    RestrictionId = m.Spartan_BR_Attribute_Restrictions_Detail_RestrictionId
                    ,Action = m.Spartan_BR_Attribute_Restrictions_Detail_Action
                    ,Attribute_Type = m.Spartan_BR_Attribute_Restrictions_Detail_Attribute_Type
                    ,Attribute_Type_Spartan_Attribute_Type = new Core.Classes.Spartan_Attribute_Type.Spartan_Attribute_Type() { Attribute_Type_Id = m.Spartan_BR_Attribute_Restrictions_Detail_Attribute_Type.GetValueOrDefault(), Description = m.Spartan_BR_Attribute_Restrictions_Detail_Attribute_Type_Description }
                    ,Control_Type = m.Spartan_BR_Attribute_Restrictions_Detail_Control_Type
                    ,Control_Type_Spartan_Attribute_Control_Type = new Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type() { ControlTypeId = m.Spartan_BR_Attribute_Restrictions_Detail_Control_Type.GetValueOrDefault(), Description = m.Spartan_BR_Attribute_Restrictions_Detail_Control_Type_Description }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Attribute_Restrictions_DetailRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "RestrictionId";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail>("sp_GetSpartan_BR_Attribute_Restrictions_Detail", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "RestrictionId";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartan_BR_Attribute_Restrictions_Detail>("sp_DelSpartan_BR_Attribute_Restrictions_Detail", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail entity)
        {
            int rta;
            try
            {

		                var padreAction = _dataProvider.GetParameter();
                padreAction.ParameterName = "Action";
                padreAction.DbType = DbType.Int32;
                padreAction.Value = (object)entity.Action ?? DBNull.Value;
                var padreAttribute_Type = _dataProvider.GetParameter();
                padreAttribute_Type.ParameterName = "Attribute_Type";
                padreAttribute_Type.DbType = DbType.Int32;
                padreAttribute_Type.Value = (object)entity.Attribute_Type ?? DBNull.Value;

                var padreControl_Type = _dataProvider.GetParameter();
                padreControl_Type.ParameterName = "Control_Type";
                padreControl_Type.DbType = DbType.Int16;
                padreControl_Type.Value = (object)entity.Control_Type ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSpartan_BR_Attribute_Restrictions_Detail>("sp_InsSpartan_BR_Attribute_Restrictions_Detail" , padreAction
, padreAttribute_Type
, padreControl_Type
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.RestrictionId);

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

        public int Update(Spartane.Core.Classes.Spartan_BR_Attribute_Restrictions_Detail.Spartan_BR_Attribute_Restrictions_Detail entity)
        {
            int rta;
            try
            {

                var paramUpdRestrictionId = _dataProvider.GetParameter();
                paramUpdRestrictionId.ParameterName = "RestrictionId";
                paramUpdRestrictionId.DbType = DbType.Int32;
                paramUpdRestrictionId.Value = entity.RestrictionId;
                var paramUpdAction = _dataProvider.GetParameter();
                paramUpdAction.ParameterName = "Action";
                paramUpdAction.DbType = DbType.Int32;
                paramUpdAction.Value = entity.Action;
                var paramUpdAttribute_Type = _dataProvider.GetParameter();
                paramUpdAttribute_Type.ParameterName = "Attribute_Type";
                paramUpdAttribute_Type.DbType = DbType.Int32;
                if (entity.Attribute_Type == null)
                    paramUpdAttribute_Type.Value = DBNull.Value;
                else
                    paramUpdAttribute_Type.Value = entity.Attribute_Type;

                var paramUpdControl_Type = _dataProvider.GetParameter();
                paramUpdControl_Type.ParameterName = "Control_Type";
                paramUpdControl_Type.DbType = DbType.Int16;
                if (entity.Control_Type == null)
                    paramUpdControl_Type.Value = DBNull.Value;
                else
                    paramUpdControl_Type.Value = entity.Control_Type;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSpartan_BR_Attribute_Restrictions_Detail>("sp_UpdSpartan_BR_Attribute_Restrictions_Detail" , paramUpdRestrictionId , paramUpdAction , paramUpdAttribute_Type , paramUpdControl_Type ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.RestrictionId);
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

