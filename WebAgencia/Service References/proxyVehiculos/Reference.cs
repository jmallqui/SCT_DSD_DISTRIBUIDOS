﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18449
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAgencia.proxyVehiculos {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Vehiculo", Namespace="http://schemas.datacontract.org/2004/07/SCTServiceWCF.Dominio")]
    [System.SerializableAttribute()]
    public partial class Vehiculo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ANNIO_FABRICACIONField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FLAG_ANULAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ID_EMPRESAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ID_VEHICULOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MARCAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MODELOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NRO_UNIDADField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PLACAField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ANNIO_FABRICACION {
            get {
                return this.ANNIO_FABRICACIONField;
            }
            set {
                if ((object.ReferenceEquals(this.ANNIO_FABRICACIONField, value) != true)) {
                    this.ANNIO_FABRICACIONField = value;
                    this.RaisePropertyChanged("ANNIO_FABRICACION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FLAG_ANULA {
            get {
                return this.FLAG_ANULAField;
            }
            set {
                if ((this.FLAG_ANULAField.Equals(value) != true)) {
                    this.FLAG_ANULAField = value;
                    this.RaisePropertyChanged("FLAG_ANULA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_EMPRESA {
            get {
                return this.ID_EMPRESAField;
            }
            set {
                if ((this.ID_EMPRESAField.Equals(value) != true)) {
                    this.ID_EMPRESAField = value;
                    this.RaisePropertyChanged("ID_EMPRESA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_VEHICULO {
            get {
                return this.ID_VEHICULOField;
            }
            set {
                if ((this.ID_VEHICULOField.Equals(value) != true)) {
                    this.ID_VEHICULOField = value;
                    this.RaisePropertyChanged("ID_VEHICULO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MARCA {
            get {
                return this.MARCAField;
            }
            set {
                if ((object.ReferenceEquals(this.MARCAField, value) != true)) {
                    this.MARCAField = value;
                    this.RaisePropertyChanged("MARCA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MODELO {
            get {
                return this.MODELOField;
            }
            set {
                if ((object.ReferenceEquals(this.MODELOField, value) != true)) {
                    this.MODELOField = value;
                    this.RaisePropertyChanged("MODELO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NRO_UNIDAD {
            get {
                return this.NRO_UNIDADField;
            }
            set {
                if ((object.ReferenceEquals(this.NRO_UNIDADField, value) != true)) {
                    this.NRO_UNIDADField = value;
                    this.RaisePropertyChanged("NRO_UNIDAD");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PLACA {
            get {
                return this.PLACAField;
            }
            set {
                if ((object.ReferenceEquals(this.PLACAField, value) != true)) {
                    this.PLACAField = value;
                    this.RaisePropertyChanged("PLACA");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="proxyVehiculos.IVehiculos")]
    public interface IVehiculos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculos/CrearVehiculo", ReplyAction="http://tempuri.org/IVehiculos/CrearVehiculoResponse")]
        WebAgencia.proxyVehiculos.Vehiculo CrearVehiculo(string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int ID_EMPRESA);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculos/ObtenerVehiculo", ReplyAction="http://tempuri.org/IVehiculos/ObtenerVehiculoResponse")]
        WebAgencia.proxyVehiculos.Vehiculo ObtenerVehiculo(int ID_VEHICULO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculos/ModificarVehiculo", ReplyAction="http://tempuri.org/IVehiculos/ModificarVehiculoResponse")]
        WebAgencia.proxyVehiculos.Vehiculo ModificarVehiculo(int ID_VEHICULO, string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int id_empresa, int FLAG_ANULA);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculos/ListarVehiculo", ReplyAction="http://tempuri.org/IVehiculos/ListarVehiculoResponse")]
        WebAgencia.proxyVehiculos.Vehiculo[] ListarVehiculo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculos/EliminarVehiculo", ReplyAction="http://tempuri.org/IVehiculos/EliminarVehiculoResponse")]
        WebAgencia.proxyVehiculos.Vehiculo EliminarVehiculo(int ID_VEHICULO, string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int id_empresa, int FLAG_ANULA);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVehiculosChannel : WebAgencia.proxyVehiculos.IVehiculos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VehiculosClient : System.ServiceModel.ClientBase<WebAgencia.proxyVehiculos.IVehiculos>, WebAgencia.proxyVehiculos.IVehiculos {
        
        public VehiculosClient() {
        }
        
        public VehiculosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VehiculosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VehiculosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VehiculosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebAgencia.proxyVehiculos.Vehiculo CrearVehiculo(string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int ID_EMPRESA) {
            return base.Channel.CrearVehiculo(PLACA, MODELO, MARCA, ANNIO_FABRICACION, NRO_UNIDAD, ID_EMPRESA);
        }
        
        public WebAgencia.proxyVehiculos.Vehiculo ObtenerVehiculo(int ID_VEHICULO) {
            return base.Channel.ObtenerVehiculo(ID_VEHICULO);
        }
        
        public WebAgencia.proxyVehiculos.Vehiculo ModificarVehiculo(int ID_VEHICULO, string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int id_empresa, int FLAG_ANULA) {
            return base.Channel.ModificarVehiculo(ID_VEHICULO, PLACA, MODELO, MARCA, ANNIO_FABRICACION, NRO_UNIDAD, id_empresa, FLAG_ANULA);
        }
        
        public WebAgencia.proxyVehiculos.Vehiculo[] ListarVehiculo() {
            return base.Channel.ListarVehiculo();
        }
        
        public WebAgencia.proxyVehiculos.Vehiculo EliminarVehiculo(int ID_VEHICULO, string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int id_empresa, int FLAG_ANULA) {
            return base.Channel.EliminarVehiculo(ID_VEHICULO, PLACA, MODELO, MARCA, ANNIO_FABRICACION, NRO_UNIDAD, id_empresa, FLAG_ANULA);
        }
    }
}