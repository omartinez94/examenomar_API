using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Spartane.Data;
using Spartane.Data.EF;
using Spartane.Services.CustomAuthentication;
using Spartane.Services.GeneratePDF;
using Spartane.Services.TTUsuarios;
using Spartane.Services.Spartan_Query;
using Spartane.Services.Spartan_Attribute_Type;
using Spartane.Services.Spartan_Control_Type;
using Spartane.Services.Spartan_Event_Type;
using Spartane.Services.Spartan_File;
using Spartane.Services.Spartan_Format;
using Spartane.Services.Spartan_Format_Type;
using Spartane.Services.Spartan_Format_Configuration;
using Spartane.Services.Spartan_Format_Field;
using Spartane.Services.Spartan_Format_Permission_Type;
using Spartane.Services.Spartan_Format_Permissions;
using Spartane.Services.Spartan_Function;
using Spartane.Services.Spartan_Function_Characteristic;
using Spartane.Services.Spartan_Function_Characteristic_Config;
using Spartane.Services.Spartan_Function_Event;
using Spartane.Services.Spartan_Function_Status;
using Spartane.Services.Spartan_Function_Type;
using Spartane.Services.Spartan_Function_Type_Status;
using Spartane.Services.Spartan_Language_Text;
using Spartane.Services.Spartan_Layout_Status;
using Spartane.Services.Spartan_Menu_Orientation;
using Spartane.Services.Spartan_Menu_Style;
using Spartane.Services.Spartan_Method_Clasification;
using Spartane.Services.Spartan_Method_Type;
using Spartane.Services.Spartan_Method_Type_Function;
using Spartane.Services.Spartan_Method_Type_Status;
using Spartane.Services.Spartan_Module;
using Spartane.Services.Spartan_Module_Config;
using Spartane.Services.Spartan_Module_Object;
using Spartane.Services.Spartan_Module_Object_Characteristic;
using Spartane.Services.Spartan_Module_Object_Method;
using Spartane.Services.Spartan_Module_Status;
using Spartane.Services.Spartan_Notice;
using Spartane.Services.Spartan_Notice_Status;
using Spartane.Services.Spartan_Notice_Type;
using Spartane.Services.Spartan_Object;
using Spartane.Services.Spartan_Object_Characteristic;
using Spartane.Services.Spartan_Object_Config;
using Spartane.Services.Spartan_Object_Method;
using Spartane.Services.Spartan_Object_Method_Characteristic;
using Spartane.Services.Spartan_Object_Method_Status;
using Spartane.Services.Spartan_Object_Path;
using Spartane.Services.Spartan_Object_Status;
using Spartane.Services.Spartan_Object_Type;
using Spartane.Services.Spartan_Order_Type;
using Spartane.Services.Spartan_Security_Event_Result;
using Spartane.Services.Spartan_Security_Event_Type;
using Spartane.Services.Spartan_Security_Log;
using Spartane.Services.Spartan_Session_Event_Type;
using Spartane.Services.Spartan_Session_Log;
using Spartane.Services.Spartan_System;
using Spartane.Services.Spartan_System_Language;
using Spartane.Services.Spartan_System_Layout;
using Spartane.Services.Spartan_Token_Type;
using Spartane.Services.Spartan_Transaction_Log;
using Spartane.Services.Spartan_Transition_Event_Type;
using Spartane.Services.Spartan_Transition_Log_Type;
using Spartane.Services.Spartan_User;
using Spartane.Services.Spartan_User_Alert;
using Spartane.Services.Spartan_User_Alert_Status;
using Spartane.Services.Spartan_User_Alert_Type;
using Spartane.Services.Spartan_User_Favorite_List;
using Spartane.Services.Spartan_User_Favorite_Object;
using Spartane.Services.Spartan_User_Most_Used_Object;
using Spartane.Services.Spartan_User_Object_Method_Config;
using Spartane.Services.Spartan_User_Quicklink;
using Spartane.Services.Spartan_User_Role;
using Spartane.Services.Spartan_User_Role_Status;
using Spartane.Services.Spartan_User_Rule_Module;
using Spartane.Services.Spartan_User_Rule_Module_Object;
using Spartane.Services.Spartan_User_Rule_Object_Function;
using Spartane.Services.Spartan_User_Status;
using Spartane.Services.Spartan_BR_Scope;
using Spartane.Services.Spartan_BR_Operation;
using Spartane.Services.Spartan_BR_Process_Event;
using Spartane.Services.Spartan_BR_Condition;
using Spartane.Services.Spartan_BR_Operator_Type;
using Spartane.Services.Spartan_BR_Condition_Operator;
using Spartane.Services.Spartan_BR_Action;
using Spartane.Services.Spartan_BR_Action_Classification;
using Spartane.Services.Spartan_BR_Action_Result;
using Spartane.Services.Spartan_Business_Rule;
using Spartane.Services.Spartan_BR_Actions_True_Detail;
using Spartane.Services.Spartan_BR_Actions_False_Detail;
using Spartane.Services.Spartan_BR_Action_Param_Type;
using Spartane.Services.Spartan_BR_Action_Configuration_Detail;
using Spartane.Services.Spartan_BR_Scope_Detail;
using Spartane.Services.Spartan_BR_Operation_Detail;
using Spartane.Services.Spartan_BR_Process_Event_Detail;
using Spartane.Services.Spartan_BR_Conditions_Detail;
using Spartane.Services.Spartan_Metadata;
using Spartane.Tools;
using Spartane.Services.Spartan_BR_Status;
using Spartane.Services.Spartan_BR_Modifications_Log;
using Spartane.Services.Spartan_BR_Presentation_Control_Type;
using Spartane.Services.Spartan_Attribute_Control_Type;
using Spartane.Services.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Services.Spartan_Report;
using Spartane.Services.Spartan_Report_Field_Type;
using Spartane.Services.Spartan_Report_Fields_Detail;
using Spartane.Services.Spartan_Report_Format;
using Spartane.Services.Spartan_Report_Function;
using Spartane.Services.Spartan_Report_Order_Type;
using Spartane.Services.Spartan_Report_Permission_Type;
using Spartane.Services.Spartan_Report_Permissions;
using Spartane.Services.Spartan_Report_Status;
using Spartane.Services.Spartan_Report_Presentation_View;
using Spartane.Services.Spartan_Report_Presentation_Type;
using Spartane.Services.Spartan_Report_Filter;
using Spartane.Core.Classes.Spartan_Additional_Menu;
using Spartane.Services.Spartan_Additional_Menu;

using Spartane.Services.Spartan_Traduction_Concept_Type;
using Spartane.Services.Spartan_Traduction_Detail;
using Spartane.Services.Spartan_Traduction_Language;
using Spartane.Services.Spartan_Traduction_Object;
using Spartane.Services.Spartan_Traduction_Object_Type;
using Spartane.Services.Spartan_Traduction_Process;

using Spartane.Services.Spartan_WorkFlow;
using Spartane.Services.Spartan_WorkFlow_Condition;
using Spartane.Services.Spartan_WorkFlow_Condition_Operator;
using Spartane.Services.Spartan_WorkFlow_Conditions_by_State;
using Spartane.Services.Spartan_WorkFlow_Information_by_State;
using Spartane.Services.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Services.Spartan_WorkFlow_Operator;
using Spartane.Services.Spartan_WorkFlow_Phase_Status;
using Spartane.Services.Spartan_WorkFlow_Phase_Type;
using Spartane.Services.Spartan_WorkFlow_Phases;
using Spartane.Services.Spartan_WorkFlow_Roles_by_State;
using Spartane.Services.Spartan_WorkFlow_State;
using Spartane.Services.Spartan_WorkFlow_Status;
using Spartane.Services.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Services.Spartan_WorkFlow_Type_Work_Distribution;

using Spartane.Services.SpartanObject;
using Spartane.Services.SpartanChangePasswordAutorizationEstatus;
using Spartane.Services.Spartan_ChangePasswordAutorization;
using Spartane.Services.Spartan_User_Historical_Password;
using Spartane.Services.Spartan_Settings;
using Spartane.Services.Spartan_Report_Advance_Filter;
using Spartane.Services.Spartan_Traduction_Process_Data;
using Spartane.Services.Spartan_Traduction_Process_Workflow;
using Spartane.Services.Spartan_Format_Related;
using Spartane.Services.Spartan_Bitacora_SQL;
using Spartane.Services.Business_Rule_Creation;
using Spartane.Services.Spartan_BR_Complexity;
using Spartane.Services.Spartan_BR_Peer_Review;
using Spartane.Services.Spartan_BR_Rejection_Reason;
using Spartane.Services.Spartan_BR_Testing;
using Spartane.Services.Spartan_BR_History;
using Spartane.Services.Spartan_BR_Type_History;


using Spartane.Services.Template_Dashboard_Editor;
using Spartane.Services.Dashboard_Status;
using Spartane.Services.Dashboard_Editor;
using Spartane.Services.Template_Dashboard_Detail;
using Spartane.Services.Dashboard_Config_Detail;
using Spartane.Services._Registro_de_Usuarios;
using Spartane.Services.Beneficios_Cualitativos;
using Spartane.Services.Detalle_Registro_Inicial_Beneficios;
using Spartane.Services.Detalle_Registro_Inicial_Prioridad;
using Spartane.Services.Estado;
using Spartane.Services.Estatus_de_Usuario;
using Spartane.Services.Estatus_Registro_Inicial;
using Spartane.Services.KPIs;
using Spartane.Services.Medida_de_tiempo;
using Spartane.Services.MS_KPIs_Impactados;
using Spartane.Services.Municipio;
using Spartane.Services.Pais;
using Spartane.Services.Prioridades_Estrategicas;
using Spartane.Services.Registro_inicial_de_iniciativa;
using Spartane.Services.Respuesta;
//**@@INCLUDE_DECLARE@@**//


namespace oAuth.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            var builder = new ContainerBuilder();

            var dataSettigs = new DataSettings();
            dataSettigs.DataConnectionString = "name=DefaultConnection";//"data source=VM-SQL2012-01;initial catalog=spartane;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            dataSettigs.DataProvider = "sqlserver";

            builder.Register(x => new EFDataProviderManager(dataSettigs)).As<BaseDataProviderManager>().InstancePerLifetimeScope();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerLifetimeScope();
            builder.Register<IDbContext>(c => new TTObjectContext(dataSettigs.DataConnectionString)).InstancePerLifetimeScope();
            builder.RegisterType<Spartan_QueryService>().As<ISpartan_QueryService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_TypeService>().As<ISpartan_Attribute_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Control_TypeService>().As<ISpartan_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Event_TypeService>().As<ISpartan_Event_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_FileService>().As<ISpartan_FileService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_FormatService>().As<ISpartan_FormatService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_TypeService>().As<ISpartan_Format_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_ConfigurationService>().As<ISpartan_Format_ConfigurationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_FieldService>().As<ISpartan_Format_FieldService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_Permission_TypeService>().As<ISpartan_Format_Permission_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_PermissionsService>().As<ISpartan_Format_PermissionsService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_Characteristic_ConfigService>().As<ISpartan_Function_Characteristic_ConfigService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_CharacteristicService>().As<ISpartan_Function_CharacteristicService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_EventService>().As<ISpartan_Function_EventService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_StatusService>().As<ISpartan_Function_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_Type_StatusService>().As<ISpartan_Function_Type_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_TypeService>().As<ISpartan_Function_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_FunctionService>().As<ISpartan_FunctionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Language_TextService>().As<ISpartan_Language_TextService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Layout_StatusService>().As<ISpartan_Layout_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Menu_OrientationService>().As<ISpartan_Menu_OrientationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Menu_StyleService>().As<ISpartan_Menu_StyleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Method_ClasificationService>().As<ISpartan_Method_ClasificationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Method_Type_FunctionService>().As<ISpartan_Method_Type_FunctionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Method_Type_StatusService>().As<ISpartan_Method_Type_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Method_TypeService>().As<ISpartan_Method_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Module_ConfigService>().As<ISpartan_Module_ConfigService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Module_Object_CharacteristicService>().As<ISpartan_Module_Object_CharacteristicService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Module_Object_MethodService>().As<ISpartan_Module_Object_MethodService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Module_ObjectService>().As<ISpartan_Module_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Module_StatusService>().As<ISpartan_Module_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ModuleService>().As<ISpartan_ModuleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Notice_StatusService>().As<ISpartan_Notice_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Notice_TypeService>().As<ISpartan_Notice_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_NoticeService>().As<ISpartan_NoticeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_CharacteristicService>().As<ISpartan_Object_CharacteristicService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_ConfigService>().As<ISpartan_Object_ConfigService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_Method_CharacteristicService>().As<ISpartan_Object_Method_CharacteristicService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_Method_StatusService>().As<ISpartan_Object_Method_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_MethodService>().As<ISpartan_Object_MethodService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_PathService>().As<ISpartan_Object_PathService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_StatusService>().As<ISpartan_Object_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_TypeService>().As<ISpartan_Object_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ObjectService>().As<ISpartan_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Order_TypeService>().As<ISpartan_Order_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Security_Event_ResultService>().As<ISpartan_Security_Event_ResultService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Security_Event_TypeService>().As<ISpartan_Security_Event_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Security_LogService>().As<ISpartan_Security_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Session_Event_TypeService>().As<ISpartan_Session_Event_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Session_LogService>().As<ISpartan_Session_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_System_LanguageService>().As<ISpartan_System_LanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_System_LayoutService>().As<ISpartan_System_LayoutService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_SystemService>().As<ISpartan_SystemService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Token_TypeService>().As<ISpartan_Token_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Transaction_LogService>().As<ISpartan_Transaction_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Transition_Event_TypeService>().As<ISpartan_Transition_Event_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Transition_Log_TypeService>().As<ISpartan_Transition_Log_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Alert_StatusService>().As<ISpartan_User_Alert_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Alert_TypeService>().As<ISpartan_User_Alert_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_AlertService>().As<ISpartan_User_AlertService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Favorite_ListService>().As<ISpartan_User_Favorite_ListService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Favorite_ObjectService>().As<ISpartan_User_Favorite_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Most_Used_ObjectService>().As<ISpartan_User_Most_Used_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Object_Method_ConfigService>().As<ISpartan_User_Object_Method_ConfigService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_QuicklinkService>().As<ISpartan_User_QuicklinkService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Role_StatusService>().As<ISpartan_User_Role_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_RoleService>().As<ISpartan_User_RoleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Rule_Module_ObjectService>().As<ISpartan_User_Rule_Module_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Rule_ModuleService>().As<ISpartan_User_Rule_ModuleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Rule_Object_FunctionService>().As<ISpartan_User_Rule_Object_FunctionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_StatusService>().As<ISpartan_User_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_UserService>().As<ISpartan_UserService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType<TTUsuariosService>().As<ITTUsuariosService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomAuthenticationService>().As<ICustomAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_QueryService>().As<ISpartan_QueryService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_Control_TypeService>().As<ISpartan_Attribute_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Business_RuleService>().As<ISpartan_Business_RuleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ActionService>().As<ISpartan_BR_ActionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Attribute_Restrictions_DetailService>().As<ISpartan_BR_Attribute_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ClassificationService>().As<ISpartan_BR_Action_ClassificationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Configuration_DetailService>().As<ISpartan_BR_Action_Configuration_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Event_Restrictions_DetailService>().As<ISpartan_BR_Event_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_False_DetailService>().As<ISpartan_BR_Actions_False_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_Restrictions_DetailService>().As<ISpartan_BR_Operation_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Param_TypeService>().As<ISpartan_BR_Action_Param_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ResultService>().As<ISpartan_BR_Action_ResultService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_True_DetailService>().As<ISpartan_BR_Actions_True_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ConditionService>().As<ISpartan_BR_ConditionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Condition_OperatorService>().As<ISpartan_BR_Condition_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Conditions_DetailService>().As<ISpartan_BR_Conditions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_OperationService>().As<ISpartan_BR_OperationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_DetailService>().As<ISpartan_BR_Operation_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operator_TypeService>().As<ISpartan_BR_Operator_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Presentation_Control_TypeService>().As<ISpartan_BR_Presentation_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_EventService>().As<ISpartan_BR_Process_EventService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_Event_DetailService>().As<ISpartan_BR_Process_Event_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ScopeService>().As<ISpartan_BR_ScopeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Scope_DetailService>().As<ISpartan_BR_Scope_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_StatusService>().As<ISpartan_BR_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Modifications_LogService>().As<ISpartan_BR_Modifications_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_MetadataService>().As<ISpartan_MetadataService>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Report_Permission_TypeService>().As<ISpartan_Report_Permission_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_PermissionsService>().As<ISpartan_Report_PermissionsService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ReportService>().As<ISpartan_ReportService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Presentation_TypeService>().As<ISpartan_Report_Presentation_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Presentation_ViewService>().As<ISpartan_Report_Presentation_ViewService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_Field_TypeService>().As<ISpartan_Report_Field_TypeService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_Fields_DetailService>().As<ISpartan_Report_Fields_DetailService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_FormatService>().As<ISpartan_Report_FormatService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_FunctionService>().As<ISpartan_Report_FunctionService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_Order_TypeService>().As<ISpartan_Report_Order_TypeService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_StatusService>().As<ISpartan_Report_StatusService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_FilterService>().As<ISpartan_Report_FilterService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_Advance_FilterService>().As<ISpartan_Report_Advance_FilterService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartane.Services.Spartan_Additional_Menu.Spartan_Additional_Menu>().As<ISpartan_Additional_Menu>().InstancePerLifetimeScope();
			builder.RegisterType<GeneratePDFService>().As<IGeneratePDFService>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Traduction_Concept_TypeService>().As<ISpartan_Traduction_Concept_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_DetailService>().As<ISpartan_Traduction_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_LanguageService>().As<ISpartan_Traduction_LanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ObjectService>().As<ISpartan_Traduction_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Object_TypeService>().As<ISpartan_Traduction_Object_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ProcessService>().As<ISpartan_Traduction_ProcessService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Process_DataService>().As<ISpartan_Traduction_Process_DataService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Process_WorkflowService>().As<ISpartan_Traduction_Process_WorkflowService>().InstancePerLifetimeScope();
            
            builder.RegisterType<Spartan_WorkFlowService>().As<ISpartan_WorkFlowService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_ConditionService>().As<ISpartan_WorkFlow_ConditionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Condition_OperatorService>().As<ISpartan_WorkFlow_Condition_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Conditions_by_StateService>().As<ISpartan_WorkFlow_Conditions_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Information_by_StateService>().As<ISpartan_WorkFlow_Information_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Matrix_of_StatesService>().As<ISpartan_WorkFlow_Matrix_of_StatesService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_OperatorService>().As<ISpartan_WorkFlow_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_StatusService>().As<ISpartan_WorkFlow_Phase_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_TypeService>().As<ISpartan_WorkFlow_Phase_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_PhasesService>().As<ISpartan_WorkFlow_PhasesService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Roles_by_StateService>().As<ISpartan_WorkFlow_Roles_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StateService>().As<ISpartan_WorkFlow_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StatusService>().As<ISpartan_WorkFlow_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Flow_ControlService>().As<ISpartan_WorkFlow_Type_Flow_ControlService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Work_DistributionService>().As<ISpartan_WorkFlow_Type_Work_DistributionService>().InstancePerLifetimeScope();

            builder.RegisterType<SpartanObjectService>().As<ISpartanObjectService>().InstancePerLifetimeScope();
            
			builder.RegisterType<SpartanChangePasswordAutorizationEstatusService>().As<ISpartanChangePasswordAutorizationEstatusService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_ChangePasswordAutorizationService>().As<ISpartan_ChangePasswordAutorizationService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_User_Historical_PasswordService>().As<ISpartan_User_Historical_PasswordService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_SettingsService>().As<ISpartan_SettingsService>().InstancePerLifetimeScope();
            
            builder.RegisterType<Spartan_Format_RelatedService>().As<ISpartan_Format_RelatedService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Bitacora_SQLService>().As<ISpartan_Bitacora_SQLService>().InstancePerLifetimeScope();
            builder.RegisterType<Business_Rule_CreationService>().As<IBusiness_Rule_CreationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ComplexityService>().As<ISpartan_BR_ComplexityService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Peer_ReviewService>().As<ISpartan_BR_Peer_ReviewService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Rejection_ReasonService>().As<ISpartan_BR_Rejection_ReasonService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_TestingService>().As<ISpartan_BR_TestingService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_HistoryService>().As<ISpartan_BR_HistoryService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Type_HistoryService>().As<ISpartan_BR_Type_HistoryService>().InstancePerLifetimeScope();
builder.RegisterType<_Registro_de_UsuariosService>().As<I_Registro_de_UsuariosService>().InstancePerLifetimeScope();
builder.RegisterType<Beneficios_CualitativosService>().As<IBeneficios_CualitativosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Registro_Inicial_BeneficiosService>().As<IDetalle_Registro_Inicial_BeneficiosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Registro_Inicial_PrioridadService>().As<IDetalle_Registro_Inicial_PrioridadService>().InstancePerLifetimeScope();
builder.RegisterType<EstadoService>().As<IEstadoService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_de_UsuarioService>().As<IEstatus_de_UsuarioService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_Registro_InicialService>().As<IEstatus_Registro_InicialService>().InstancePerLifetimeScope();
builder.RegisterType<KPIsService>().As<IKPIsService>().InstancePerLifetimeScope();
builder.RegisterType<Medida_de_tiempoService>().As<IMedida_de_tiempoService>().InstancePerLifetimeScope();
builder.RegisterType<MS_KPIs_ImpactadosService>().As<IMS_KPIs_ImpactadosService>().InstancePerLifetimeScope();
builder.RegisterType<MunicipioService>().As<IMunicipioService>().InstancePerLifetimeScope();
builder.RegisterType<PaisService>().As<IPaisService>().InstancePerLifetimeScope();
builder.RegisterType<Prioridades_EstrategicasService>().As<IPrioridades_EstrategicasService>().InstancePerLifetimeScope();
builder.RegisterType<Registro_inicial_de_iniciativaService>().As<IRegistro_inicial_de_iniciativaService>().InstancePerLifetimeScope();
builder.RegisterType<RespuestaService>().As<IRespuestaService>().InstancePerLifetimeScope();
//**@@INCLUDE_EXPOSE@@**//
            GlobalConfiguration.Configuration.EnsureInitialized();

            //// Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            //// Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //// OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<Template_Dashboard_EditorService>().As<ITemplate_Dashboard_EditorService>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_StatusService>().As<IDashboard_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_EditorService>().As<IDashboard_EditorService>().InstancePerLifetimeScope();
            builder.RegisterType<Template_Dashboard_DetailService>().As<ITemplate_Dashboard_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_Config_DetailService>().As<IDashboard_Config_DetailService>().InstancePerLifetimeScope();

            //// Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }
    }
}


































