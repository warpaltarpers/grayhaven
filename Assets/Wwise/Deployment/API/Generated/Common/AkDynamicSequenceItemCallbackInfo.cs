#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class AkDynamicSequenceItemCallbackInfo : AkCallbackInfo {
  private IntPtr swigCPtr;

  internal AkDynamicSequenceItemCallbackInfo(IntPtr cPtr, bool cMemoryOwn) : base(AkSoundEnginePINVOKE.CSharp_AkDynamicSequenceItemCallbackInfo_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = cPtr;
  }

  internal static IntPtr getCPtr(AkDynamicSequenceItemCallbackInfo obj) {
    return (obj == null) ? IntPtr.Zero : obj.swigCPtr;
  }

  ~AkDynamicSequenceItemCallbackInfo() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkDynamicSequenceItemCallbackInfo(swigCPtr);
        }
        swigCPtr = IntPtr.Zero;
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public uint playingID {
    get {
      uint ret = AkSoundEnginePINVOKE.CSharp_AkDynamicSequenceItemCallbackInfo_playingID_get(swigCPtr);

      return ret;
    } 
  }

  public uint audioNodeID {
    get {
      uint ret = AkSoundEnginePINVOKE.CSharp_AkDynamicSequenceItemCallbackInfo_audioNodeID_get(swigCPtr);

      return ret;
    } 
  }

  public IntPtr pCustomInfo { get { return AkSoundEnginePINVOKE.CSharp_AkDynamicSequenceItemCallbackInfo_pCustomInfo_get(swigCPtr);
 }
  }

  public AkDynamicSequenceItemCallbackInfo() : this(AkSoundEnginePINVOKE.CSharp_new_AkDynamicSequenceItemCallbackInfo(), true) {

  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.