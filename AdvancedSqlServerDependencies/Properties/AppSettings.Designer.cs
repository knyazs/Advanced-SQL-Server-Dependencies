//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdvancedSqlServerDependencies.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class AppSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static AppSettings defaultInstance = ((AppSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new AppSettings())));
        
        public static AppSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastConnectionString {
            get {
                return ((string)(this["LastConnectionString"]));
            }
            set {
                this["LastConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool DependencySearchDirectionTopDown {
            get {
                return ((bool)(this["DependencySearchDirectionTopDown"]));
            }
            set {
                this["DependencySearchDirectionTopDown"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastSearches {
            get {
                return ((string)(this["LastSearches"]));
            }
            set {
                this["LastSearches"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Contains")]
        public string ObjectMatchMethod {
            get {
                return ((string)(this["ObjectMatchMethod"]));
            }
            set {
                this["ObjectMatchMethod"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ForceObjectAndDependencyReload {
            get {
                return ((bool)(this["ForceObjectAndDependencyReload"]));
            }
            set {
                this["ForceObjectAndDependencyReload"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("No object selected")]
        public string NoObjectSelectedDefaultText {
            get {
                return ((string)(this["NoObjectSelectedDefaultText"]));
            }
            set {
                this["NoObjectSelectedDefaultText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastOption {
            get {
                return ((string)(this["LastOption"]));
            }
            set {
                this["LastOption"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ApplicationRated {
            get {
                return ((int)(this["ApplicationRated"]));
            }
            set {
                this["ApplicationRated"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastObjectTypes {
            get {
                return ((string)(this["LastObjectTypes"]));
            }
            set {
                this["LastObjectTypes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SuppressWelcomePage {
            get {
                return ((bool)(this["SuppressWelcomePage"]));
            }
            set {
                this["SuppressWelcomePage"] = value;
            }
        }
    }
}
