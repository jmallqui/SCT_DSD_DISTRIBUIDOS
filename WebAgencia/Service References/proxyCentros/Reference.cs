﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18449
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAgencia.proxyCentros {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Centro", Namespace="http://schemas.datacontract.org/2004/07/SCTServiceWCF.Dominio")]
    [System.SerializableAttribute()]
    public partial class Centro : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DESCRIPCIONField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EMPRESAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ID_CENTROField;
        
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
        public string DESCRIPCION {
            get {
                return this.DESCRIPCIONField;
            }
            set {
                if ((object.ReferenceEquals(this.DESCRIPCIONField, value) != true)) {
                    this.DESCRIPCIONField = value;
                    this.RaisePropertyChanged("DESCRIPCION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EMPRESA {
            get {
                return this.EMPRESAField;
            }
            set {
                if ((this.EMPRESAField.Equals(value) != true)) {
                    this.EMPRESAField = value;
                    this.RaisePropertyChanged("EMPRESA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_CENTRO {
            get {
                return this.ID_CENTROField;
            }
            set {
                if ((this.ID_CENTROField.Equals(value) != true)) {
                    this.ID_CENTROField = value;
                    this.RaisePropertyChanged("ID_CENTRO");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="proxyCentros.ICentro")]
    public interface ICentro {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentro/CrearCentro", ReplyAction="http://tempuri.org/ICentro/CrearCentroResponse")]
        WebAgencia.proxyCentros.Centro CrearCentro(string descripcion, int empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentro/ObtenerCentro", ReplyAction="http://tempuri.org/ICentro/ObtenerCentroResponse")]
        WebAgencia.proxyCentros.Centro ObtenerCentro(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentro/ModificarCentro", ReplyAction="http://tempuri.org/ICentro/ModificarCentroResponse")]
        WebAgencia.proxyCentros.Centro ModificarCentro(int codigo, string descripcion, int empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentro/ListarCentro", ReplyAction="http://tempuri.org/ICentro/ListarCentroResponse")]
        WebAgencia.proxyCentros.Centro[] ListarCentro();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICentroChannel : WebAgencia.proxyCentros.ICentro, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CentroClient : System.ServiceModel.ClientBase<WebAgencia.proxyCentros.ICentro>, WebAgencia.proxyCentros.ICentro {
        
        public CentroClient() {
        }
        
        public CentroClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CentroClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CentroClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CentroClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebAgencia.proxyCentros.Centro CrearCentro(string descripcion, int empresa) {
            return base.Channel.CrearCentro(descripcion, empresa);
        }
        
        public WebAgencia.proxyCentros.Centro ObtenerCentro(int codigo) {
            return base.Channel.ObtenerCentro(codigo);
        }
        
        public WebAgencia.proxyCentros.Centro ModificarCentro(int codigo, string descripcion, int empresa) {
            return base.Channel.ModificarCentro(codigo, descripcion, empresa);
        }
        
        public WebAgencia.proxyCentros.Centro[] ListarCentro() {
            return base.Channel.ListarCentro();
        }
    }
}