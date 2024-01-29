/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2017                    */
/* Created on:     26/1/2024 20:55:07                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ASIENTOS') and o.name = 'FK_ASIENTOS_SALA_CINE_SALA_CIN')
alter table ASIENTOS
   drop constraint FK_ASIENTOS_SALA_CINE_SALA_CIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BOLETOS') and o.name = 'FK_BOLETOS_BOLETOS_T_TICKET')
alter table BOLETOS
   drop constraint FK_BOLETOS_BOLETOS_T_TICKET
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURA') and o.name = 'FK_FACTURA_FACTURA_P_PEDIDO_C')
alter table FACTURA
   drop constraint FK_FACTURA_FACTURA_P_PEDIDO_C
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HORARIO') and o.name = 'FK_HORARIO_PELICULA__PELICULA')
alter table HORARIO
   drop constraint FK_HORARIO_PELICULA__PELICULA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HORARIO') and o.name = 'FK_HORARIO_SALA_CINE_SALA_CIN')
alter table HORARIO
   drop constraint FK_HORARIO_SALA_CINE_SALA_CIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LINEAS_PEDIDO') and o.name = 'FK_LINEAS_P_LINEAS_PE_PEDIDO_C')
alter table LINEAS_PEDIDO
   drop constraint FK_LINEAS_P_LINEAS_PE_PEDIDO_C
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PAGOS') and o.name = 'FK_PAGOS_PAGOS_FAC_FACTURA')
alter table PAGOS
   drop constraint FK_PAGOS_PAGOS_FAC_FACTURA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PEDIDO_COMPRA') and o.name = 'FK_PEDIDO_C_PEDIDOCOM_PROVEEDO')
alter table PEDIDO_COMPRA
   drop constraint FK_PEDIDO_C_PEDIDOCOM_PROVEEDO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PEDIDO_COMPRA') and o.name = 'FK_PEDIDO_C_PEDIDO_CO_ESTADO_P')
alter table PEDIDO_COMPRA
   drop constraint FK_PEDIDO_C_PEDIDO_CO_ESTADO_P
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PELICULA') and o.name = 'FK_PELICULA_PELICULA__LINEAS_P')
alter table PELICULA
   drop constraint FK_PELICULA_PELICULA__LINEAS_P
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PELICULA_REPARTO_REL') and o.name = 'FK_PELICULA_PELICULA__PELICULA')
alter table PELICULA_REPARTO_REL
   drop constraint FK_PELICULA_PELICULA__PELICULA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PELICULA_REPARTO_REL') and o.name = 'FK_PELICULA_PELICULA__REPARTO')
alter table PELICULA_REPARTO_REL
   drop constraint FK_PELICULA_PELICULA__REPARTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ROL') and o.name = 'FK_ROL_ROL_USUAR_USUARIO')
alter table ROL
   drop constraint FK_ROL_ROL_USUAR_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TICKET') and o.name = 'FK_TICKET_BOLETO_SA_SALA_CIN')
alter table TICKET
   drop constraint FK_TICKET_BOLETO_SA_SALA_CIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TICKET') and o.name = 'FK_TICKET_USUARIO_T_USUARIO')
alter table TICKET
   drop constraint FK_TICKET_USUARIO_T_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_ROL_USUAR_ROL')
alter table USUARIO
   drop constraint FK_USUARIO_ROL_USUAR_ROL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ASIENTOS')
            and   name  = 'SALA_CINE_ASIENTOS_FK'
            and   indid > 0
            and   indid < 255)
   drop index ASIENTOS.SALA_CINE_ASIENTOS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ASIENTOS')
            and   type = 'U')
   drop table ASIENTOS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BOLETOS')
            and   name  = 'BOLETOS_TICKET_FK'
            and   indid > 0
            and   indid < 255)
   drop index BOLETOS.BOLETOS_TICKET_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BOLETOS')
            and   type = 'U')
   drop table BOLETOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ESTADO_PEDIDO')
            and   type = 'U')
   drop table ESTADO_PEDIDO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FACTURA')
            and   name  = 'FACTURA_PEDIDO_COMPRA_FK'
            and   indid > 0
            and   indid < 255)
   drop index FACTURA.FACTURA_PEDIDO_COMPRA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FACTURA')
            and   type = 'U')
   drop table FACTURA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HORARIO')
            and   name  = 'PELICULA_HORARIO_FK'
            and   indid > 0
            and   indid < 255)
   drop index HORARIO.PELICULA_HORARIO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HORARIO')
            and   name  = 'SALA_CINE_HORARIO_FK'
            and   indid > 0
            and   indid < 255)
   drop index HORARIO.SALA_CINE_HORARIO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HORARIO')
            and   type = 'U')
   drop table HORARIO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LINEAS_PEDIDO')
            and   name  = 'LINEAS_PEDIDO_PEDID_COMPRA_FK'
            and   indid > 0
            and   indid < 255)
   drop index LINEAS_PEDIDO.LINEAS_PEDIDO_PEDID_COMPRA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LINEAS_PEDIDO')
            and   type = 'U')
   drop table LINEAS_PEDIDO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PAGOS')
            and   name  = 'PAGOS_FACTURA_FK'
            and   indid > 0
            and   indid < 255)
   drop index PAGOS.PAGOS_FACTURA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PAGOS')
            and   type = 'U')
   drop table PAGOS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PEDIDO_COMPRA')
            and   name  = 'PEDIDO_COMPRA_ESTADO_FK'
            and   indid > 0
            and   indid < 255)
   drop index PEDIDO_COMPRA.PEDIDO_COMPRA_ESTADO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PEDIDO_COMPRA')
            and   name  = 'PEDIDOCOMPRA_PROVEEDOR_FK'
            and   indid > 0
            and   indid < 255)
   drop index PEDIDO_COMPRA.PEDIDOCOMPRA_PROVEEDOR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PEDIDO_COMPRA')
            and   type = 'U')
   drop table PEDIDO_COMPRA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PELICULA')
            and   name  = 'PELICULA_LINEA_PEDIDO_FK'
            and   indid > 0
            and   indid < 255)
   drop index PELICULA.PELICULA_LINEA_PEDIDO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PELICULA')
            and   type = 'U')
   drop table PELICULA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PELICULA_REPARTO_REL')
            and   name  = 'PELICULA_REPLICULA_REPARTO_FK'
            and   indid > 0
            and   indid < 255)
   drop index PELICULA_REPARTO_REL.PELICULA_REPLICULA_REPARTO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PELICULA_REPARTO_REL')
            and   name  = 'PELICULA_REPARTO_REPARTO_FK'
            and   indid > 0
            and   indid < 255)
   drop index PELICULA_REPARTO_REL.PELICULA_REPARTO_REPARTO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PELICULA_REPARTO_REL')
            and   type = 'U')
   drop table PELICULA_REPARTO_REL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PROVEEDOR')
            and   type = 'U')
   drop table PROVEEDOR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REPARTO')
            and   type = 'U')
   drop table REPARTO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ROL')
            and   name  = 'ROL_USUARIO_FK'
            and   indid > 0
            and   indid < 255)
   drop index ROL.ROL_USUARIO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROL')
            and   type = 'U')
   drop table ROL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SALA_CINE')
            and   type = 'U')
   drop table SALA_CINE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TICKET')
            and   name  = 'USUARIO_TICKET_FK'
            and   indid > 0
            and   indid < 255)
   drop index TICKET.USUARIO_TICKET_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TICKET')
            and   type = 'U')
   drop table TICKET
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('USUARIO')
            and   name  = 'ROL_USUARIO2_FK'
            and   indid > 0
            and   indid < 255)
   drop index USUARIO.ROL_USUARIO2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: ASIENTOS                                              */
/*==============================================================*/
create table ASIENTOS (
   ID_ASIENTOS          int                  identity,
   ID_SALA_CINE         int                  not null,
   FECHA_CREACION_ASIENTOS datetime           DEFAULT GETDATE() not null,
   ACTIVO_ASIENTOS      bit                  default 1 not null,
   FILA                 varchar(3)           not null,
   COLUMNA              varchar(3)           not null,
   DISPONIBILIDAD       bit                  default 1 not null,
   constraint PK_ASIENTOS primary key (ID_ASIENTOS)
)
go

/*==============================================================*/
/* Index: SALA_CINE_ASIENTOS_FK                                 */
/*==============================================================*/




create nonclustered index SALA_CINE_ASIENTOS_FK on ASIENTOS (ID_SALA_CINE ASC)
go

/*==============================================================*/
/* Table: BOLETOS                                               */
/*==============================================================*/
create table BOLETOS (
   ID_SALA_CINE         int                  identity,
   ID_BOLETOS           int                  not null,
   FECHA_CREACION_BOLETOS datetime           DEFAULT GETDATE() not null,
   ACTIVO_BOLETOS       bit                  default 1 not null,
   CODIGO_TICKET        varchar(30)          not null,
   constraint PK_BOLETOS primary key (ID_SALA_CINE)
)
go

/*==============================================================*/
/* Index: BOLETOS_TICKET_FK                                     */
/*==============================================================*/




create nonclustered index BOLETOS_TICKET_FK on BOLETOS (ID_SALA_CINE ASC)
go

/*==============================================================*/
/* Table: ESTADO_PEDIDO                                         */
/*==============================================================*/
create table ESTADO_PEDIDO (
   ID_ESTADO_PEDIDO     int                  identity,
   TIPO_ESTADO_PEDIDO   varchar(1024)        not null,
   FECHA_CREACION_ESTADO_PEDIDO datetime           DEFAULT GETDATE() not null,
   ACTIVO_ESTADO_PEDIDO bit                  default 1 not null,
   constraint PK_ESTADO_PEDIDO primary key (ID_ESTADO_PEDIDO)
)
go

/*==============================================================*/
/* Table: FACTURA                                               */
/*==============================================================*/
create table FACTURA (
   ID_PEDIDO_COMPRA     int                  identity,
   ID_FACTURA           int                  not null,
   NUMERO_FACTURA       varchar(20)          not null,
   FECHA_CREACION_FACTURA datetime           DEFAULT GETDATE() not null,
   ACTIVO_FACTURA       bit                  default 1 not null,
   FECHA_EXPEDICION     datetime             not null,
   ESTADO_PAGO          varchar(10)          null,
   constraint PK_FACTURA primary key (ID_PEDIDO_COMPRA, ID_FACTURA)
)
go

/*==============================================================*/
/* Index: FACTURA_PEDIDO_COMPRA_FK                              */
/*==============================================================*/




create nonclustered index FACTURA_PEDIDO_COMPRA_FK on FACTURA (ID_PEDIDO_COMPRA ASC)
go

/*==============================================================*/
/* Table: HORARIO                                               */
/*==============================================================*/
create table HORARIO (
   ID_HORARIO           int                  identity,
   ID_SALA_CINE         int                  not null,
   ID_PELICULA          int                  not null,
   FECHA_CREACION_HORARIO datetime           DEFAULT GETDATE() not null,
   ACTIVO_HORARIO       bit                  default 1 not null,
   HORA_INICIO          varchar(5)           not null,
   FECHA                datetime             not null,
   constraint PK_HORARIO primary key (ID_HORARIO)
)
go

/*==============================================================*/
/* Index: SALA_CINE_HORARIO_FK                                  */
/*==============================================================*/




create nonclustered index SALA_CINE_HORARIO_FK on HORARIO (ID_SALA_CINE ASC)
go

/*==============================================================*/
/* Index: PELICULA_HORARIO_FK                                   */
/*==============================================================*/




create nonclustered index PELICULA_HORARIO_FK on HORARIO (ID_PELICULA ASC)
go

/*==============================================================*/
/* Table: LINEAS_PEDIDO                                         */
/*==============================================================*/
create table LINEAS_PEDIDO (
   ID_LINEAS_PEDIDO     int                  identity,
   ID_PEDIDO_COMPRA     int                  not null,
   FECHA_CREACION_LINEAS_PEDIDO datetime           DEFAULT GETDATE() not null,
   ACTIVO_LINEAS_PEDIDO bit                  default 1 not null,
   CANTIDAD             int                  not null,
   PRECIO               float                not null,
   SUBTOTAL             float                not null,
   constraint PK_LINEAS_PEDIDO primary key (ID_LINEAS_PEDIDO)
)
go

/*==============================================================*/
/* Index: LINEAS_PEDIDO_PEDID_COMPRA_FK                         */
/*==============================================================*/




create nonclustered index LINEAS_PEDIDO_PEDID_COMPRA_FK on LINEAS_PEDIDO (ID_PEDIDO_COMPRA ASC)
go

/*==============================================================*/
/* Table: PAGOS                                                 */
/*==============================================================*/
create table PAGOS (
   ID_PAGOS             int                  identity,
   ID_PEDIDO_COMPRA     int                  null,
   ID_FACTURA           int                  null,
   MONTO                float(32)            not null,
   FECHA_CREACION_PAGOS datetime           DEFAULT GETDATE() not null,
   ACTIVO_PAGOS         bit                  default 1 not null,
   constraint PK_PAGOS primary key (ID_PAGOS)
)
go

/*==============================================================*/
/* Index: PAGOS_FACTURA_FK                                      */
/*==============================================================*/




create nonclustered index PAGOS_FACTURA_FK on PAGOS (ID_PEDIDO_COMPRA ASC,
  ID_FACTURA ASC)
go

/*==============================================================*/
/* Table: PEDIDO_COMPRA                                         */
/*==============================================================*/
create table PEDIDO_COMPRA (
   ID_PEDIDO_COMPRA     int                  identity,
   ID_PROVEEDOR         int                  not null,
   ID_ESTADO_PEDIDO     int                  null,
   NUMERO_PEDIDO_COMPRA varchar(1024)        not null,
   ACTIVO_PEDIDO_COMPRA bit                  default 1 not null,
   FECHA_ENTREGA        date                 null,
   TOTAL                float                not null,
   FECHA_CREACION_PEDIDO_COMPRA datetime           DEFAULT GETDATE() not null,
   constraint PK_PEDIDO_COMPRA primary key (ID_PEDIDO_COMPRA)
)
go

/*==============================================================*/
/* Index: PEDIDOCOMPRA_PROVEEDOR_FK                             */
/*==============================================================*/




create nonclustered index PEDIDOCOMPRA_PROVEEDOR_FK on PEDIDO_COMPRA (ID_PROVEEDOR ASC)
go

/*==============================================================*/
/* Index: PEDIDO_COMPRA_ESTADO_FK                               */
/*==============================================================*/




create nonclustered index PEDIDO_COMPRA_ESTADO_FK on PEDIDO_COMPRA (ID_ESTADO_PEDIDO ASC)
go

/*==============================================================*/
/* Table: PELICULA                                              */
/*==============================================================*/
create table PELICULA (
   ID_PELICULA          int                  identity,
   ID_LINEAS_PEDIDO     int                  null,
   TITULO               varchar(1024)        not null,
   CATEGORIA            varchar(1024)        not null,
   RESTRICCION          varchar(1024)        not null,
   SINOPSIS             varchar(1)           null,
   TRAILER_URL          varchar(1024)        null,
   CALIFICACION         int                  null,
   FECHA_CREACION_PELICULA datetime           DEFAULT GETDATE() not null,
   ACTIVO_PELICULA      bit                  default 1 not null,
   CANTIDAD_PELICULA    int                  not null,
   constraint PK_PELICULA primary key (ID_PELICULA)
)
go

/*==============================================================*/
/* Index: PELICULA_LINEA_PEDIDO_FK                              */
/*==============================================================*/




create nonclustered index PELICULA_LINEA_PEDIDO_FK on PELICULA (ID_LINEAS_PEDIDO ASC)
go

/*==============================================================*/
/* Table: PELICULA_REPARTO_REL                                  */
/*==============================================================*/
create table PELICULA_REPARTO_REL (
   ID_PELICULA          int                  not null,
   ID_REPARTO           int                  not null,
   constraint PK_PELICULA_REPARTO_REL primary key (ID_PELICULA, ID_REPARTO)
)
go

/*==============================================================*/
/* Index: PELICULA_REPARTO_REPARTO_FK                           */
/*==============================================================*/




create nonclustered index PELICULA_REPARTO_REPARTO_FK on PELICULA_REPARTO_REL (ID_PELICULA ASC)
go

/*==============================================================*/
/* Index: PELICULA_REPLICULA_REPARTO_FK                         */
/*==============================================================*/




create nonclustered index PELICULA_REPLICULA_REPARTO_FK on PELICULA_REPARTO_REL (ID_REPARTO ASC)
go

/*==============================================================*/
/* Table: PROVEEDOR                                             */
/*==============================================================*/
create table PROVEEDOR (
   ID_PROVEEDOR         int                  identity,
   FECHA_CREACION_PROVEEDOR datetime           DEFAULT GETDATE() not null,
   ACTIVO_PROVEEDOR     bit                  default 1 not null,
   NOMBRE_PROVEEDOR     varchar(1024)        not null,
   APELLIDO_PROVEEDOR   char(1024)           not null,
   IDENTIFICACION_PROVEEDOR char(13)             not null,
   DIRECCION_PROVEEDOR  char(1024)           null,
   TELEFONO_PROVEEDOR   char(20)             null,
   CORREO_PROVEEDOR     varchar(100)         not null,
   constraint PK_PROVEEDOR primary key (ID_PROVEEDOR)
)
go

/*==============================================================*/
/* Table: REPARTO                                               */
/*==============================================================*/
create table REPARTO (
   ID_REPARTO           int                  identity,
   NOMBRE               varchar(1024)        not null,
   FECHA_CREACION_REPARTO datetime           DEFAULT GETDATE() not null,
   ACTIVO_REPARTO       bit                  default 1 not null,
   constraint PK_REPARTO primary key (ID_REPARTO)
)
go

/*==============================================================*/
/* Table: ROL                                                   */
/*==============================================================*/
create table ROL (
   ID_ROL               int                  identity,
   ID_USUARIO           int                  null,
   TIPO_ROL             varchar(50)          not null,
   DESCRIPCION          varchar(100)         null,
   FECHA_CREACION_ROL   datetime           DEFAULT GETDATE() not null,
   ACTIVO_ROL           bit                  default 1 not null,
   constraint PK_ROL primary key (ID_ROL)
)
go

/*==============================================================*/
/* Index: ROL_USUARIO_FK                                        */
/*==============================================================*/




create nonclustered index ROL_USUARIO_FK on ROL (ID_USUARIO ASC)
go

/*==============================================================*/
/* Table: SALA_CINE                                             */
/*==============================================================*/
create table SALA_CINE (
   ID_SALA_CINE         int                  identity,
   FECHA_CREACION_SALA_CINE datetime           DEFAULT GETDATE() not null,
   ACTIVO_SALA_CINE     bit                  default 1 not null,
   NUMERO               varchar(100)         not null,
   CAPACIDAD            int                  not null,
   constraint PK_SALA_CINE primary key (ID_SALA_CINE)
)
go

/*==============================================================*/
/* Table: TICKET                                                */
/*==============================================================*/
create table TICKET (
   ID_SALA_CINE         int                  identity,
   ID_USUARIO           int                  null,
   ID_TICKET            int                  not null,
   CODIGO_COMPRA        varchar(50)          not null,
   FECHA_CREACION_      datetime           DEFAULT GETDATE() not null,
   ACTIVO_TICKET        bit                  default 1 not null,
   constraint PK_TICKET primary key (ID_SALA_CINE)
)
go

/*==============================================================*/
/* Index: USUARIO_TICKET_FK                                     */
/*==============================================================*/




create nonclustered index USUARIO_TICKET_FK on TICKET (ID_USUARIO ASC)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   ID_USUARIO           int                  identity,
   ID_ROL               int                  null,
   LOGIN                varchar(50)          not null,
   CONTRASENA           varchar(50)          not null,
   FECHA_CREACION_USUARIO datetime           DEFAULT GETDATE() not null,
   ACTIVO_USUARIO       bit                  default 1 not null,
   NOMBRE_USUARIO       varchar(100)         not null,
   APELLIDO_USUARIO     char(100)            not null,
   IDENTIFICACION_USUARIO char(13)             not null,
   DIRECCION_USUARIO    char(200)            null,
   TELEFONO_USUARIO     char(20)             null,
   CORREO_USUARIO       varchar(50)          not null,
   constraint PK_USUARIO primary key (ID_USUARIO)
)
go

/*==============================================================*/
/* Index: ROL_USUARIO2_FK                                       */
/*==============================================================*/




create nonclustered index ROL_USUARIO2_FK on USUARIO (ID_ROL ASC)
go

alter table ASIENTOS
   add constraint FK_ASIENTOS_SALA_CINE_SALA_CIN foreign key (ID_SALA_CINE)
      references SALA_CINE (ID_SALA_CINE)
go

alter table BOLETOS
   add constraint FK_BOLETOS_BOLETOS_T_TICKET foreign key (ID_SALA_CINE)
      references TICKET (ID_SALA_CINE)
go

alter table FACTURA
   add constraint FK_FACTURA_FACTURA_P_PEDIDO_C foreign key (ID_PEDIDO_COMPRA)
      references PEDIDO_COMPRA (ID_PEDIDO_COMPRA)
go

alter table HORARIO
   add constraint FK_HORARIO_PELICULA__PELICULA foreign key (ID_PELICULA)
      references PELICULA (ID_PELICULA)
go

alter table HORARIO
   add constraint FK_HORARIO_SALA_CINE_SALA_CIN foreign key (ID_SALA_CINE)
      references SALA_CINE (ID_SALA_CINE)
go

alter table LINEAS_PEDIDO
   add constraint FK_LINEAS_P_LINEAS_PE_PEDIDO_C foreign key (ID_PEDIDO_COMPRA)
      references PEDIDO_COMPRA (ID_PEDIDO_COMPRA)
go

alter table PAGOS
   add constraint FK_PAGOS_PAGOS_FAC_FACTURA foreign key (ID_PEDIDO_COMPRA, ID_FACTURA)
      references FACTURA (ID_PEDIDO_COMPRA, ID_FACTURA)
go

alter table PEDIDO_COMPRA
   add constraint FK_PEDIDO_C_PEDIDOCOM_PROVEEDO foreign key (ID_PROVEEDOR)
      references PROVEEDOR (ID_PROVEEDOR)
go

alter table PEDIDO_COMPRA
   add constraint FK_PEDIDO_C_PEDIDO_CO_ESTADO_P foreign key (ID_ESTADO_PEDIDO)
      references ESTADO_PEDIDO (ID_ESTADO_PEDIDO)
go

alter table PELICULA
   add constraint FK_PELICULA_PELICULA__LINEAS_P foreign key (ID_LINEAS_PEDIDO)
      references LINEAS_PEDIDO (ID_LINEAS_PEDIDO)
go

alter table PELICULA_REPARTO_REL
   add constraint FK_PELICULA_PELICULA__PELICULA foreign key (ID_PELICULA)
      references PELICULA (ID_PELICULA)
go

alter table PELICULA_REPARTO_REL
   add constraint FK_PELICULA_PELICULA__REPARTO foreign key (ID_REPARTO)
      references REPARTO (ID_REPARTO)
go

alter table ROL
   add constraint FK_ROL_ROL_USUAR_USUARIO foreign key (ID_USUARIO)
      references USUARIO (ID_USUARIO)
go

alter table TICKET
   add constraint FK_TICKET_BOLETO_SA_SALA_CIN foreign key (ID_SALA_CINE)
      references SALA_CINE (ID_SALA_CINE)
go

alter table TICKET
   add constraint FK_TICKET_USUARIO_T_USUARIO foreign key (ID_USUARIO)
      references USUARIO (ID_USUARIO)
go

alter table USUARIO
   add constraint FK_USUARIO_ROL_USUAR_ROL foreign key (ID_ROL)
      references ROL (ID_ROL)
go




/*PROCEDIMIENTOS ALMACENADOS*/

/*ASIENTO*/

CREATE PROCEDURE InsertarAsiento
    @ID_SALA_CINE INT,
    @FILA VARCHAR(3),
    @COLUMNA VARCHAR(3)
AS
BEGIN
    INSERT INTO ASIENTOS (ID_SALA_CINE, FILA, COLUMNA)
    VALUES (@ID_SALA_CINE, @FILA, @COLUMNA);
END;
GO

CREATE PROCEDURE ObtenerAsientos
AS
BEGIN
    SELECT * FROM ASIENTOS;
END;
GO

CREATE PROCEDURE ActualizarAsiento
    @ID_ASIENTOS INT,
    @ID_SALA_CINE INT,
    @FILA VARCHAR(3),
    @COLUMNA VARCHAR(3)
AS
BEGIN
    UPDATE ASIENTOS
    SET ID_SALA_CINE = @ID_SALA_CINE,
        FILA = @FILA,
        COLUMNA = @COLUMNA
    WHERE ID_ASIENTOS = @ID_ASIENTOS;
END;
GO

CREATE PROCEDURE EliminarAsiento
    @ID_ASIENTOS INT
AS
BEGIN
    DELETE FROM ASIENTOS
    WHERE ID_ASIENTOS = @ID_ASIENTOS;
END;
GO

/*USUARIOS*/

CREATE PROCEDURE InsertarUsuario
    @ID_ROL INT,
    @LOGIN VARCHAR(50),
    @CONTRASENA VARCHAR(50),
    @NOMBRE_USUARIO VARCHAR(100),
    @APELLIDO_USUARIO CHAR(100),
    @IDENTIFICACION_USUARIO CHAR(13),
    @DIRECCION_USUARIO CHAR(200),
    @TELEFONO_USUARIO CHAR(20),
    @CORREO_USUARIO VARCHAR(50)
AS
BEGIN
    INSERT INTO USUARIO (ID_ROL, LOGIN, CONTRASENA, NOMBRE_USUARIO, APELLIDO_USUARIO, IDENTIFICACION_USUARIO, DIRECCION_USUARIO, TELEFONO_USUARIO, CORREO_USUARIO)
    VALUES (@ID_ROL, @LOGIN, @CONTRASENA, @NOMBRE_USUARIO, @APELLIDO_USUARIO, @IDENTIFICACION_USUARIO, @DIRECCION_USUARIO, @TELEFONO_USUARIO, @CORREO_USUARIO);
END
GO


CREATE PROCEDURE ObtenerUsuarioPorID
    @ID_USUARIO INT
AS
BEGIN
    SELECT *
    FROM USUARIO
    WHERE ID_USUARIO = @ID_USUARIO;
END
GO

CREATE PROCEDURE ActualizarUsuario
    @ID_USUARIO INT,
    @ID_ROL INT,
    @LOGIN VARCHAR(50),
    @CONTRASENA VARCHAR(50),
    @NOMBRE_USUARIO VARCHAR(100),
    @APELLIDO_USUARIO CHAR(100),
    @IDENTIFICACION_USUARIO CHAR(13),
    @DIRECCION_USUARIO CHAR(200),
    @TELEFONO_USUARIO CHAR(20),
    @CORREO_USUARIO VARCHAR(50)
AS
BEGIN
    UPDATE USUARIO
    SET
        ID_ROL = @ID_ROL,
        LOGIN = @LOGIN,
        CONTRASENA = @CONTRASENA,
        NOMBRE_USUARIO = @NOMBRE_USUARIO,
        APELLIDO_USUARIO = @APELLIDO_USUARIO,
        IDENTIFICACION_USUARIO = @IDENTIFICACION_USUARIO,
        DIRECCION_USUARIO = @DIRECCION_USUARIO,
        TELEFONO_USUARIO = @TELEFONO_USUARIO,
        CORREO_USUARIO = @CORREO_USUARIO
    WHERE ID_USUARIO = @ID_USUARIO;
END
GO

CREATE PROCEDURE EliminarUsuario
    @ID_USUARIO INT
AS
BEGIN
    DELETE FROM USUARIO
    WHERE ID_USUARIO = @ID_USUARIO;
END
GO

/*PELICULA*/

CREATE PROCEDURE InsertarPelicula
    @ID_LINEAS_PEDIDO INT,
    @TITULO VARCHAR(1024),
    @CATEGORIA VARCHAR(1024),
    @RESTRICCION VARCHAR(1024),
    @SINOPSIS VARCHAR(1),
    @TRAILER_URL VARCHAR(1024),
    @CALIFICACION INT,
    @CANTIDAD_PELICULA INT
AS
BEGIN
    INSERT INTO PELICULA (ID_LINEAS_PEDIDO, TITULO, CATEGORIA, RESTRICCION, SINOPSIS, TRAILER_URL, CALIFICACION, CANTIDAD_PELICULA)
    VALUES (@ID_LINEAS_PEDIDO, @TITULO, @CATEGORIA, @RESTRICCION, @SINOPSIS, @TRAILER_URL, @CALIFICACION, @CANTIDAD_PELICULA);
END;
GO

CREATE PROCEDURE ObtenerPeliculas
AS
BEGIN
    SELECT *
    FROM PELICULA;
END;
GO

CREATE PROCEDURE ObtenerPeliculaPorID
    @ID_PELICULA INT
AS
BEGIN
    SELECT *
    FROM PELICULA
    WHERE ID_PELICULA = @ID_PELICULA;
END;
GO

CREATE PROCEDURE ActualizarPelicula
    @ID_PELICULA INT,
    @ID_LINEAS_PEDIDO INT,
    @TITULO VARCHAR(1024),
    @CATEGORIA VARCHAR(1024),
    @RESTRICCION VARCHAR(1024),
    @SINOPSIS VARCHAR(1),
    @TRAILER_URL VARCHAR(1024),
    @CALIFICACION INT,
    @CANTIDAD_PELICULA INT
AS
BEGIN
    UPDATE PELICULA
    SET
        ID_LINEAS_PEDIDO = @ID_LINEAS_PEDIDO,
        TITULO = @TITULO,
        CATEGORIA = @CATEGORIA,
        RESTRICCION = @RESTRICCION,
        SINOPSIS = @SINOPSIS,
        TRAILER_URL = @TRAILER_URL,
        CALIFICACION = @CALIFICACION,
        CANTIDAD_PELICULA = @CANTIDAD_PELICULA
    WHERE ID_PELICULA = @ID_PELICULA;
END;
GO

CREATE PROCEDURE EliminarPelicula
    @ID_PELICULA INT
AS
BEGIN
    DELETE FROM PELICULA
    WHERE ID_PELICULA = @ID_PELICULA;
END;
GO

/*ASIENTOS*/

CREATE PROCEDURE InsertarAsiento
    @ID_SALA_CINE INT,
    @FILA VARCHAR(3),
    @COLUMNA VARCHAR(3)
AS
BEGIN
    INSERT INTO ASIENTOS (ID_SALA_CINE, FILA, COLUMNA)
    VALUES (@ID_SALA_CINE, @FILA, @COLUMNA);
END;
GO

CREATE PROCEDURE ObtenerAsientos
AS
BEGIN
    SELECT * FROM ASIENTOS;
END;
GO

CREATE PROCEDURE ActualizarAsiento
    @ID_ASIENTOS INT,
    @ID_SALA_CINE INT,
    @FILA VARCHAR(3),
    @COLUMNA VARCHAR(3)
AS
BEGIN
    UPDATE ASIENTOS
    SET ID_SALA_CINE = @ID_SALA_CINE,
        FILA = @FILA,
        COLUMNA = @COLUMNA
    WHERE ID_ASIENTOS = @ID_ASIENTOS;
END;
GO

CREATE PROCEDURE EliminarAsiento
    @ID_ASIENTOS INT
AS
BEGIN
    DELETE FROM ASIENTOS
    WHERE ID_ASIENTOS = @ID_ASIENTOS;
END;
GO

/*BOLETOS*/


CREATE PROCEDURE InsertarBoleto
    @ID_BOLETOS int,
    @CODIGO_TICKET varchar(30)
AS
BEGIN
    INSERT INTO BOLETOS (ID_BOLETOS, FECHA_CREACION_BOLETOS, ACTIVO_BOLETOS, CODIGO_TICKET)
    VALUES (@ID_BOLETOS, GETDATE(), 1, @CODIGO_TICKET);
END;
GO

CREATE PROCEDURE ObtenerBoletos
AS
BEGIN
    SELECT ID_SALA_CINE, ID_BOLETOS, FECHA_CREACION_BOLETOS, ACTIVO_BOLETOS, CODIGO_TICKET
    FROM BOLETOS;
END;
GO

CREATE PROCEDURE ActualizarBoleto
    @ID_SALA_CINE int,
    @ID_BOLETOS int,
    @CODIGO_TICKET varchar(30)
AS
BEGIN
    UPDATE BOLETOS
    SET ID_BOLETOS = @ID_BOLETOS,
        CODIGO_TICKET = @CODIGO_TICKET
    WHERE ID_SALA_CINE = @ID_SALA_CINE;
END;
GO

CREATE PROCEDURE EliminarBoleto
    @ID_SALA_CINE int
AS
BEGIN
    DELETE FROM BOLETOS
    WHERE ID_SALA_CINE = @ID_SALA_CINE;
END;
GO

/*ESTADO PEDIDO*/

CREATE PROCEDURE InsertarEstadoPedido
    @TIPO_ESTADO_PEDIDO   varchar(1024),
    @ACTIVO_ESTADO_PEDIDO bit
AS
BEGIN
    INSERT INTO ESTADO_PEDIDO (TIPO_ESTADO_PEDIDO, FECHA_CREACION_ESTADO_PEDIDO, ACTIVO_ESTADO_PEDIDO)
    VALUES (@TIPO_ESTADO_PEDIDO, GETDATE(), @ACTIVO_ESTADO_PEDIDO);
END;
GO

CREATE PROCEDURE ObtenerTodosEstadosPedido
AS
BEGIN
    SELECT * FROM ESTADO_PEDIDO;
END;
GO

CREATE PROCEDURE ObtenerEstadoPedidoPorID
    @ID_ESTADO_PEDIDO int
AS
BEGIN
    SELECT * FROM ESTADO_PEDIDO WHERE ID_ESTADO_PEDIDO = @ID_ESTADO_PEDIDO;
END;
GO

CREATE PROCEDURE ActualizarEstadoPedido
    @ID_ESTADO_PEDIDO     int,
    @TIPO_ESTADO_PEDIDO   varchar(1024),
    @ACTIVO_ESTADO_PEDIDO bit
AS
BEGIN
    UPDATE ESTADO_PEDIDO
    SET TIPO_ESTADO_PEDIDO = @TIPO_ESTADO_PEDIDO,
        ACTIVO_ESTADO_PEDIDO = @ACTIVO_ESTADO_PEDIDO
    WHERE ID_ESTADO_PEDIDO = @ID_ESTADO_PEDIDO;
END;
GO

CREATE PROCEDURE EliminarEstadoPedido
    @ID_ESTADO_PEDIDO int
AS
BEGIN
    DELETE FROM ESTADO_PEDIDO WHERE ID_ESTADO_PEDIDO = @ID_ESTADO_PEDIDO;
END;
GO

/*FACTURA*/

CREATE PROCEDURE InsertarFactura
    @ID_FACTURA INT,
    @NUMERO_FACTURA VARCHAR(20),
    @FECHA_EXPEDICION DATETIME,
    @ESTADO_PAGO VARCHAR(10)
AS
BEGIN
    INSERT INTO FACTURA (ID_FACTURA, NUMERO_FACTURA, FECHA_EXPEDICION, ESTADO_PAGO)
    VALUES (@ID_FACTURA, @NUMERO_FACTURA, @FECHA_EXPEDICION, @ESTADO_PAGO);
END;
GO

CREATE PROCEDURE ObtenerFactura
    @ID_PEDIDO_COMPRA INT,
    @ID_FACTURA INT
AS
BEGIN
    SELECT * FROM FACTURA
    WHERE ID_PEDIDO_COMPRA = @ID_PEDIDO_COMPRA AND ID_FACTURA = @ID_FACTURA;
END;
GO

CREATE PROCEDURE ObtenerFacturaPorID
	@ID_FACTURA INT
AS
BEGIN
	SELECT * FROM FACTURA
	WHERE ID_FACTURA = @ID_FACTURA;
END;
GO

CREATE PROCEDURE ActualizarFactura
    @ID_PEDIDO_COMPRA INT,
    @ID_FACTURA INT,
    @NUMERO_FACTURA VARCHAR(20),
    @FECHA_EXPEDICION DATETIME,
    @ESTADO_PAGO VARCHAR(10)
AS
BEGIN
    UPDATE FACTURA
    SET 
        NUMERO_FACTURA = @NUMERO_FACTURA,
        FECHA_EXPEDICION = @FECHA_EXPEDICION,
        ESTADO_PAGO = @ESTADO_PAGO
    WHERE ID_PEDIDO_COMPRA = @ID_PEDIDO_COMPRA AND ID_FACTURA = @ID_FACTURA;
END;
GO

CREATE PROCEDURE EliminarFactura
    @ID_FACTURA INT
AS
BEGIN
    DELETE FROM FACTURA
    WHERE ID_FACTURA = @ID_FACTURA;
END;
GO

/*HORARIO*/


CREATE PROCEDURE usp_InsertarHorario
    @ID_SALA_CINE int,
    @ID_PELICULA int,
    @HORA_INICIO varchar(5),
    @FECHA datetime
AS
BEGIN
    INSERT INTO HORARIO (ID_SALA_CINE, ID_PELICULA, HORA_INICIO, FECHA)
    VALUES (@ID_SALA_CINE, @ID_PELICULA, @HORA_INICIO, @FECHA);
END;

GO

CREATE PROCEDURE usp_SeleccionarHorarios
AS
BEGIN
    SELECT * FROM HORARIO;
END;
GO

CREATE PROCEDURE usp_ActualizarHorario
    @ID_HORARIO int,
    @ID_SALA_CINE int,
    @ID_PELICULA int,
    @HORA_INICIO varchar(5),
    @FECHA datetime
AS
BEGIN
    UPDATE HORARIO
    SET ID_SALA_CINE = @ID_SALA_CINE,
        ID_PELICULA = @ID_PELICULA,
        HORA_INICIO = @HORA_INICIO,
        FECHA = @FECHA
    WHERE ID_HORARIO = @ID_HORARIO;
END;
GO

CREATE PROCEDURE usp_EliminarHorario
    @ID_HORARIO int
AS
BEGIN
    DELETE FROM HORARIO
    WHERE ID_HORARIO = @ID_HORARIO;
END;
GO


/*PROVEEDOR*/
-- INSERTAR UN PROVEEDOR
CREATE PROCEDURE InsertarProveedor
    @NOMBRE_PROVEEDOR varchar(1024),
    @APELLIDO_PROVEEDOR char(1024),
    @IDENTIFICACION_PROVEEDOR char(13),
    @DIRECCION_PROVEEDOR char(1024) = NULL,
    @TELEFONO_PROVEEDOR char(20) = NULL,
    @CORREO_PROVEEDOR varchar(100)
AS
BEGIN
    INSERT INTO PROVEEDOR (FECHA_CREACION_PROVEEDOR, ACTIVO_PROVEEDOR, NOMBRE_PROVEEDOR, APELLIDO_PROVEEDOR, IDENTIFICACION_PROVEEDOR, DIRECCION_PROVEEDOR, TELEFONO_PROVEEDOR, CORREO_PROVEEDOR)
    VALUES (GETDATE(), 1, @NOMBRE_PROVEEDOR, @APELLIDO_PROVEEDOR, @IDENTIFICACION_PROVEEDOR, @DIRECCION_PROVEEDOR, @TELEFONO_PROVEEDOR, @CORREO_PROVEEDOR);
END;
GO

-- OBTENER TODOS LOS PROVEEDORES
CREATE PROCEDURE ObtenerProveedores
AS
BEGIN
    SELECT * FROM PROVEEDOR;
END;
GO

-- OBTENER UN PROVEEDOR POR SU ID
CREATE PROCEDURE ObtenerProveedorPorID
    @ID_PROVEEDOR INT
AS
BEGIN
    SELECT * FROM PROVEEDOR
    WHERE ID_PROVEEDOR = @ID_PROVEEDOR;
END;
GO

-- ACTUALIZAR UN PROVEEDOR
CREATE PROCEDURE ActualizarProveedor
    @ID_PROVEEDOR INT,
    @NOMBRE_PROVEEDOR varchar(1024),
    @APELLIDO_PROVEEDOR char(1024),
    @IDENTIFICACION_PROVEEDOR char(13),
    @DIRECCION_PROVEEDOR char(1024) = NULL,
    @TELEFONO_PROVEEDOR char(20) = NULL,
    @CORREO_PROVEEDOR varchar(100)
AS
BEGIN
    UPDATE PROVEEDOR
    SET
        NOMBRE_PROVEEDOR = @NOMBRE_PROVEEDOR,
        APELLIDO_PROVEEDOR = @APELLIDO_PROVEEDOR,
        IDENTIFICACION_PROVEEDOR = @IDENTIFICACION_PROVEEDOR,
        DIRECCION_PROVEEDOR = @DIRECCION_PROVEEDOR,
        TELEFONO_PROVEEDOR = @TELEFONO_PROVEEDOR,
        CORREO_PROVEEDOR = @CORREO_PROVEEDOR
    WHERE ID_PROVEEDOR = @ID_PROVEEDOR;
END;
GO

-- ELIMINAR UN PROVEEDOR
CREATE PROCEDURE EliminarProveedor
    @ID_PROVEEDOR INT
AS
BEGIN
    DELETE FROM PROVEEDOR
    WHERE ID_PROVEEDOR = @ID_PROVEEDOR;
END;
GO


/*LÍNEAS DE PEDIDO*/
-- INSERTAR UNA LÍNEA DE PEDIDO
CREATE PROCEDURE InsertarLineaPedido
    @ID_PEDIDO_COMPRA INT,
    @CANTIDAD INT,
    @PRECIO FLOAT,
    @SUBTOTAL FLOAT OUTPUT
AS
BEGIN
    INSERT INTO LINEAS_PEDIDO (ID_PEDIDO_COMPRA, CANTIDAD, PRECIO, SUBTOTAL)
    VALUES (@ID_PEDIDO_COMPRA, @CANTIDAD, @PRECIO, @CANTIDAD * @PRECIO);

    SET @SUBTOTAL = @CANTIDAD * @PRECIO;
END;
GO

-- OBTENER TODAS LAS LÍNEAS DE PEDIDO
CREATE PROCEDURE ObtenerLineasPedido
AS
BEGIN
    SELECT *
    FROM LINEAS_PEDIDO;
END;
GO

-- OBTENER UNA LÍNEA DE PEDIDO POR SU ID
CREATE PROCEDURE ObtenerLineaPedidoPorID
    @ID_LINEAS_PEDIDO INT
AS
BEGIN
    SELECT *
    FROM LINEAS_PEDIDO
    WHERE ID_LINEAS_PEDIDO = @ID_LINEAS_PEDIDO;
END;
GO

-- ACTUALIZAR UNA LÍNEA DE PEDIDO
CREATE PROCEDURE ActualizarLineaPedido
    @ID_LINEAS_PEDIDO INT,
    @ID_PEDIDO_COMPRA INT,
    @CANTIDAD INT,
    @PRECIO FLOAT,
    @SUBTOTAL FLOAT OUTPUT
AS
BEGIN
    UPDATE LINEAS_PEDIDO
    SET
        ID_PEDIDO_COMPRA = @ID_PEDIDO_COMPRA,
        CANTIDAD = @CANTIDAD,
        PRECIO = @PRECIO,
        SUBTOTAL = @CANTIDAD * @PRECIO
    WHERE ID_LINEAS_PEDIDO = @ID_LINEAS_PEDIDO;

    SET @SUBTOTAL = @CANTIDAD * @PRECIO;
END;
GO

-- ELIMINAR UNA LÍNEA DE PEDIDO
CREATE PROCEDURE EliminarLineaPedido
    @ID_LINEAS_PEDIDO INT
AS
BEGIN
    DELETE FROM LINEAS_PEDIDO
    WHERE ID_LINEAS_PEDIDO = @ID_LINEAS_PEDIDO;
END;
GO

/*PAGOS*/

-- Insertar un Pago
CREATE PROCEDURE InsertarPago
    @ID_PEDIDO_COMPRA INT,
    @ID_FACTURA INT,
    @MONTO FLOAT,
    @ACTIVO_PAGOS BIT
AS
BEGIN
    INSERT INTO PAGOS (ID_PEDIDO_COMPRA, ID_FACTURA, MONTO, ACTIVO_PAGOS)
    VALUES (@ID_PEDIDO_COMPRA, @ID_FACTURA, @MONTO, @ACTIVO_PAGOS);
END;
GO

-- Obtener Todos los Pagos
CREATE PROCEDURE ObtenerPagos
AS
BEGIN
    SELECT *
    FROM PAGOS;
END;
GO

-- Obtener un Pago por su ID
CREATE PROCEDURE ObtenerPagoPorID
    @ID_PAGOS INT
AS
BEGIN
    SELECT *
    FROM PAGOS
    WHERE ID_PAGOS = @ID_PAGOS;
END;
GO

-- Actualizar un Pago
CREATE PROCEDURE ActualizarPago
    @ID_PAGOS INT,
    @ID_PEDIDO_COMPRA INT,
    @ID_FACTURA INT,
    @MONTO FLOAT,
    @ACTIVO_PAGOS BIT
AS
BEGIN
    UPDATE PAGOS
    SET
        ID_PEDIDO_COMPRA = @ID_PEDIDO_COMPRA,
        ID_FACTURA = @ID_FACTURA,
        MONTO = @MONTO,
        ACTIVO_PAGOS = @ACTIVO_PAGOS
    WHERE ID_PAGOS = @ID_PAGOS;
END;
GO

-- Eliminar un Pago por su ID
CREATE PROCEDURE EliminarPago
    @ID_PAGOS INT
AS
BEGIN
    DELETE FROM PAGOS
    WHERE ID_PAGOS = @ID_PAGOS;
END;
GO

/*PEDIDO COMPRA*/

-- INSERTAR UN PEDIDO DE COMPRA
CREATE PROCEDURE InsertarPedidoCompra
    @ID_PROVEEDOR INT,
    @ID_ESTADO_PEDIDO INT,
    @NUMERO_PEDIDO_COMPRA VARCHAR(1024),
    @FECHA_ENTREGA DATE,
    @TOTAL FLOAT
AS
BEGIN
    INSERT INTO PEDIDO_COMPRA (ID_PROVEEDOR, ID_ESTADO_PEDIDO, NUMERO_PEDIDO_COMPRA, FECHA_ENTREGA, TOTAL)
    VALUES (@ID_PROVEEDOR, @ID_ESTADO_PEDIDO, @NUMERO_PEDIDO_COMPRA, @FECHA_ENTREGA, @TOTAL);
END;
GO

-- OBTENER TODOS LOS PEDIDOS DE COMPRA
CREATE PROCEDURE ObtenerPedidosCompra
AS
BEGIN
    SELECT *
    FROM PEDIDO_COMPRA;
END;
GO

-- OBTENER UN PEDIDO DE COMPRA POR SU ID
CREATE PROCEDURE ObtenerPedidoCompraPorID
    @ID_PEDIDO_COMPRA INT
AS
BEGIN
    SELECT *
    FROM PEDIDO_COMPRA
    WHERE ID_PEDIDO_COMPRA = @ID_PEDIDO_COMPRA;
END;
GO

-- ACTUALIZAR UN PEDIDO DE COMPRA
CREATE PROCEDURE ActualizarPedidoCompra
    @ID_PEDIDO_COMPRA INT,
    @ID_PROVEEDOR INT,
    @ID_ESTADO_PEDIDO INT,
    @NUMERO_PEDIDO_COMPRA VARCHAR(1024),
    @FECHA_ENTREGA DATE,
    @TOTAL FLOAT
AS
BEGIN
    UPDATE PEDIDO_COMPRA
    SET
        ID_PROVEEDOR = @ID_PROVEEDOR,
        ID_ESTADO_PEDIDO = @ID_ESTADO_PEDIDO,
        NUMERO_PEDIDO_COMPRA = @NUMERO_PEDIDO_COMPRA,
        FECHA_ENTREGA = @FECHA_ENTREGA,
        TOTAL = @TOTAL
    WHERE ID_PEDIDO_COMPRA = @ID_PEDIDO_COMPRA;
END;
GO

-- ELIMINAR UN PEDIDO DE COMPRA
CREATE PROCEDURE EliminarPedidoCompra
    @ID_PEDIDO_COMPRA INT
AS
BEGIN
    DELETE FROM PEDIDO_COMPRA
    WHERE ID_PEDIDO_COMPRA = @ID_PEDIDO_COMPRA;
END;
GO


/*REPARTO*/

-- insertar un nuevo registro en la tabla REPARTO
CREATE PROCEDURE InsertarReparto
    @NOMBRE varchar(1024)
AS
BEGIN
    INSERT INTO REPARTO (NOMBRE)
    VALUES (@NOMBRE);
END;
GO

-- obtener todos los registros de la tabla REPARTO
CREATE PROCEDURE ObtenerRepartos
AS
BEGIN
    SELECT *
    FROM REPARTO;
END;
GO

-- obtener un solo registro de la tabla REPARTO por ID
CREATE PROCEDURE ObtenerRepartoPorID
    @ID_REPARTO INT
AS
BEGIN
    SELECT *
    FROM REPARTO
    WHERE ID_REPARTO = @ID_REPARTO;
END;
GO

-- actualizar un registro en la tabla REPARTO
CREATE PROCEDURE ActualizarReparto
    @ID_REPARTO INT,
    @NOMBRE varchar(1024)
AS
BEGIN
    UPDATE REPARTO
    SET
        NOMBRE = @NOMBRE
    WHERE ID_REPARTO = @ID_REPARTO;
END;
GO

-- eliminar un registro de la tabla REPARTO por ID
CREATE PROCEDURE EliminarReparto
    @ID_REPARTO INT
AS
BEGIN
    DELETE FROM REPARTO
    WHERE ID_REPARTO = @ID_REPARTO;
END;
GO


/*ROL*/
-- insertar un nuevo registro en la tabla ROL
CREATE PROCEDURE InsertarRol
    @ID_USUARIO INT,
    @TIPO_ROL VARCHAR(50),
    @DESCRIPCION VARCHAR(100)
AS
BEGIN
    INSERT INTO ROL (ID_USUARIO, TIPO_ROL, DESCRIPCION)
    VALUES (@ID_USUARIO, @TIPO_ROL, @DESCRIPCION);
END;
GO

-- obtener todos los registros de la tabla ROL
CREATE PROCEDURE ObtenerRoles
AS
BEGIN
    SELECT *
    FROM ROL;
END;
GO

-- obtener un solo registro de la tabla ROL por ID
CREATE PROCEDURE ObtenerRolPorID
    @ID_ROL INT
AS
BEGIN
    SELECT *
    FROM ROL
    WHERE ID_ROL = @ID_ROL;
END;
GO

-- actualizar un registro en la tabla ROL
CREATE PROCEDURE ActualizarRol
    @ID_ROL INT,
    @ID_USUARIO INT,
    @TIPO_ROL VARCHAR(50),
    @DESCRIPCION VARCHAR(100)
AS
BEGIN
    UPDATE ROL
    SET
        ID_USUARIO = @ID_USUARIO,
        TIPO_ROL = @TIPO_ROL,
        DESCRIPCION = @DESCRIPCION
    WHERE ID_ROL = @ID_ROL;
END;
GO

-- eliminar un registro de la tabla ROL
CREATE PROCEDURE EliminarRol
    @ID_ROL INT
AS
BEGIN
    DELETE FROM ROL
    WHERE ID_ROL = @ID_ROL;
END;
GO

/*SALA CINE*/
-- insertar una nueva sala de cine
CREATE PROCEDURE InsertarSalaCine
    @NUMERO VARCHAR(100),
    @CAPACIDAD INT
AS
BEGIN
    INSERT INTO SALA_CINE (NUMERO, CAPACIDAD)
    VALUES (@NUMERO, @CAPACIDAD);
END;
GO

-- obtener todas las salas de cine
CREATE PROCEDURE ObtenerSalasCine
AS
BEGIN
    SELECT *
    FROM SALA_CINE;
END;
GO

-- obtener una sala de cine por su ID_SALA_CINE
CREATE PROCEDURE ObtenerSalaCinePorID
    @ID_SALA_CINE INT
AS
BEGIN
    SELECT *
    FROM SALA_CINE
    WHERE ID_SALA_CINE = @ID_SALA_CINE;
END;
GO

-- actualizar una sala de cine
CREATE PROCEDURE ActualizarSalaCine
    @ID_SALA_CINE INT,
    @NUMERO VARCHAR(100),
    @CAPACIDAD INT
AS
BEGIN
    UPDATE SALA_CINE
    SET
        NUMERO = @NUMERO,
        CAPACIDAD = @CAPACIDAD
    WHERE ID_SALA_CINE = @ID_SALA_CINE;
END;
GO

-- eliminar una sala de cine
CREATE PROCEDURE EliminarSalaCine
    @ID_SALA_CINE INT
AS
BEGIN
    DELETE FROM SALA_CINE
    WHERE ID_SALA_CINE = @ID_SALA_CINE;
END;
GO

/*TICKET*/
-- insertar un nuevo registro
CREATE PROCEDURE InsertarTicket
    @ID_USUARIO INT,
    @CODIGO_COMPRA VARCHAR(50)
AS
BEGIN
    INSERT INTO TICKET (ID_USUARIO, CODIGO_COMPRA)
    VALUES (@ID_USUARIO, @CODIGO_COMPRA);
END;
GO

-- obtener todos los registros
CREATE PROCEDURE ObtenerTickets
AS
BEGIN
    SELECT * FROM TICKET;
END;
GO

-- obtener un solo registro por ID_TICKET
CREATE PROCEDURE ObtenerTicketPorID
    @ID_TICKET INT
AS
BEGIN
    SELECT * FROM TICKET
    WHERE ID_TICKET = @ID_TICKET;
END;
GO

-- actualizar un registro existente
CREATE PROCEDURE ActualizarTicket
    @ID_SALA_CINE INT,
    @ID_USUARIO INT,
    @CODIGO_COMPRA VARCHAR(50)
AS
BEGIN
    UPDATE TICKET
    SET
        ID_USUARIO = @ID_USUARIO,
        CODIGO_COMPRA = @CODIGO_COMPRA
    WHERE ID_SALA_CINE = @ID_SALA_CINE;
END;
GO

-- eliminar un registro por ID_SALA_CINE
CREATE PROCEDURE EliminarTicket
    @ID_SALA_CINE INT
AS
BEGIN
    DELETE FROM TICKET
    WHERE ID_SALA_CINE = @ID_SALA_CINE;
END;
GO
