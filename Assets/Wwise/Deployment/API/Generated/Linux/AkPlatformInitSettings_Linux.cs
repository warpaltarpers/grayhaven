#if UNITY_STANDALONE_LINUX && ! UNITY_EDITOR
/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class AkPlatformInitSettings : IDisposable {
  private IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkPlatformInitSettings(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static IntPtr getCPtr(AkPlatformInitSettings obj) {
    return (obj == null) ? IntPtr.Zero : obj.swigCPtr;
  }

  ~AkPlatformInitSettings() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkPlatformInitSettings(swigCPtr);
        }
        swigCPtr = IntPtr.Zero;
      }
      GC.SuppressFinalize(this);
    }
  }

  public AkThreadProperties threadLEngine {
    set {
      AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_threadLEngine_set(swigCPtr, AkThreadProperties.getCPtr(value));

    } 
    get {
      IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_threadLEngine_get(swigCPtr);
      AkThreadProperties ret = (cPtr == IntPtr.Zero) ? null : new AkThreadProperties(cPtr, false);

      return ret;
    } 
  }

  public AkThreadProperties threadBankManager {
    set {
      AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_threadBankManager_set(swigCPtr, AkThreadProperties.getCPtr(value));

    } 
    get {
      IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_threadBankManager_get(swigCPtr);
      AkThreadProperties ret = (cPtr == IntPtr.Zero) ? null : new AkThreadProperties(cPtr, false);

      return ret;
    } 
  }

  public AkThreadProperties threadMonitor {
    set {
      AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_threadMonitor_set(swigCPtr, AkThreadProperties.getCPtr(value));

    } 
    get {
      IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_threadMonitor_get(swigCPtr);
      AkThreadProperties ret = (cPtr == IntPtr.Zero) ? null : new AkThreadProperties(cPtr, false);

      return ret;
    } 
  }

  public float fLEngineDefaultPoolRatioThreshold {
    set {
      AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_fLEngineDefaultPoolRatioThreshold_set(swigCPtr, value);

    } 
    get {
      float ret = AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_fLEngineDefaultPoolRatioThreshold_get(swigCPtr);

      return ret;
    } 
  }

  public uint uLEngineDefaultPoolSize {
    set {
      AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_uLEngineDefaultPoolSize_set(swigCPtr, value);

    } 
    get {
      uint ret = AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_uLEngineDefaultPoolSize_get(swigCPtr);

      return ret;
    } 
  }

  public uint uSampleRate {
    set {
      AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_uSampleRate_set(swigCPtr, value);

    } 
    get {
      uint ret = AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_uSampleRate_get(swigCPtr);

      return ret;
    } 
  }

  public ushort uNumRefillsInVoice {
    set {
      AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_uNumRefillsInVoice_set(swigCPtr, value);

    } 
    get {
      ushort ret = AkSoundEnginePINVOKE.CSharp_AkPlatformInitSettings_uNumRefillsInVoice_get(swigCPtr);

      return ret;
    } 
  }

  public AkPlatformInitSettings() : this(AkSoundEnginePINVOKE.CSharp_new_AkPlatformInitSettings(), true) {

  }

}
#endif // #if UNITY_STANDALONE_LINUX && ! UNITY_EDITOR