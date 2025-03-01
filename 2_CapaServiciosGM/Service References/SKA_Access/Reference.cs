﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _2_CapaServiciosGM.SKA_Access {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SKA_Access.WebServicesSecuritySoap")]
    public interface WebServicesSecuritySoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que la operación getLista no es RPC ni está encapsulada en un documento.
        [System.ServiceModel.OperationContractAttribute(Action="getLista", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BaseXml))]
        _2_CapaServiciosGM.SKA_Access.getListaResponse getLista(_2_CapaServiciosGM.SKA_Access.getListaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="getLista", ReplyAction="*")]
        System.Threading.Tasks.Task<_2_CapaServiciosGM.SKA_Access.getListaResponse> getListaAsync(_2_CapaServiciosGM.SKA_Access.getListaRequest request);
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    public partial class ArchivoXML : object, System.ComponentModel.INotifyPropertyChanged {
        
        private EResponse eEResponseField;
        
        private EAutorizacion[] eAutorizacionLstField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public EResponse EEResponse {
            get {
                return this.eEResponseField;
            }
            set {
                this.eEResponseField = value;
                this.RaisePropertyChanged("EEResponse");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public EAutorizacion[] EAutorizacionLst {
            get {
                return this.eAutorizacionLstField;
            }
            set {
                this.eAutorizacionLstField = value;
                this.RaisePropertyChanged("EAutorizacionLst");
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
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class EResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private Status statusField;
        
        private string mensajeField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public Status status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("status");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string mensaje {
            get {
                return this.mensajeField;
            }
            set {
                this.mensajeField = value;
                this.RaisePropertyChanged("mensaje");
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
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum Status {
        
        /// <comentarios/>
        Ok,
        
        /// <comentarios/>
        Error,
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EAutorizacion))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class BaseXml : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3221.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class EAutorizacion : BaseXml {
        
        private string ordenField;
        
        private string descripcionField;
        
        private string valorField;
        
        private string parametroField;
        
        private string mensajeField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Orden {
            get {
                return this.ordenField;
            }
            set {
                this.ordenField = value;
                this.RaisePropertyChanged("Orden");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("Descripcion");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Valor {
            get {
                return this.valorField;
            }
            set {
                this.valorField = value;
                this.RaisePropertyChanged("Valor");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Parametro {
            get {
                return this.parametroField;
            }
            set {
                this.parametroField = value;
                this.RaisePropertyChanged("Parametro");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Mensaje {
            get {
                return this.mensajeField;
            }
            set {
                this.mensajeField = value;
                this.RaisePropertyChanged("Mensaje");
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getListaRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string Parametros;
        
        public getListaRequest() {
        }
        
        public getListaRequest(string Parametros) {
            this.Parametros = Parametros;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getListaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public _2_CapaServiciosGM.SKA_Access.ArchivoXML ArchivoXML;
        
        public getListaResponse() {
        }
        
        public getListaResponse(_2_CapaServiciosGM.SKA_Access.ArchivoXML ArchivoXML) {
            this.ArchivoXML = ArchivoXML;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServicesSecuritySoapChannel : _2_CapaServiciosGM.SKA_Access.WebServicesSecuritySoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServicesSecuritySoapClient : System.ServiceModel.ClientBase<_2_CapaServiciosGM.SKA_Access.WebServicesSecuritySoap>, _2_CapaServiciosGM.SKA_Access.WebServicesSecuritySoap {
        
        public WebServicesSecuritySoapClient() {
        }
        
        public WebServicesSecuritySoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServicesSecuritySoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServicesSecuritySoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServicesSecuritySoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _2_CapaServiciosGM.SKA_Access.getListaResponse _2_CapaServiciosGM.SKA_Access.WebServicesSecuritySoap.getLista(_2_CapaServiciosGM.SKA_Access.getListaRequest request) {
            return base.Channel.getLista(request);
        }
        
        public _2_CapaServiciosGM.SKA_Access.ArchivoXML getLista(string Parametros) {
            _2_CapaServiciosGM.SKA_Access.getListaRequest inValue = new _2_CapaServiciosGM.SKA_Access.getListaRequest();
            inValue.Parametros = Parametros;
            _2_CapaServiciosGM.SKA_Access.getListaResponse retVal = ((_2_CapaServiciosGM.SKA_Access.WebServicesSecuritySoap)(this)).getLista(inValue);
            return retVal.ArchivoXML;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<_2_CapaServiciosGM.SKA_Access.getListaResponse> _2_CapaServiciosGM.SKA_Access.WebServicesSecuritySoap.getListaAsync(_2_CapaServiciosGM.SKA_Access.getListaRequest request) {
            return base.Channel.getListaAsync(request);
        }
        
        public System.Threading.Tasks.Task<_2_CapaServiciosGM.SKA_Access.getListaResponse> getListaAsync(string Parametros) {
            _2_CapaServiciosGM.SKA_Access.getListaRequest inValue = new _2_CapaServiciosGM.SKA_Access.getListaRequest();
            inValue.Parametros = Parametros;
            return ((_2_CapaServiciosGM.SKA_Access.WebServicesSecuritySoap)(this)).getListaAsync(inValue);
        }
    }
}
