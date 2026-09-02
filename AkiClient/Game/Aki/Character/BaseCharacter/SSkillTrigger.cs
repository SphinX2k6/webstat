using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004281 RID: 17025
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillTrigger.SSkillTrigger")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class SSkillTrigger : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D385 RID: 185221 RVA: 0x00ABA64C File Offset: 0x00AB884C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillTrigger._ScriptStructPtr != 0) ? SSkillTrigger._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillTrigger.SSkillTrigger", ref SSkillTrigger._ScriptStructPtr);
		}

		// Token: 0x17007B38 RID: 31544
		// (get) Token: 0x0602D386 RID: 185222 RVA: 0x00ABA670 File Offset: 0x00AB8870
		// (set) Token: 0x0602D387 RID: 185223 RVA: 0x00ABA684 File Offset: 0x00AB8884
		public unsafe string TriggerType
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTrigger.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTrigger.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007B39 RID: 31545
		// (get) Token: 0x0602D388 RID: 185224 RVA: 0x00ABA69C File Offset: 0x00AB889C
		// (set) Token: 0x0602D389 RID: 185225 RVA: 0x00ABA6DF File Offset: 0x00AB88DF
		public TArray<string> TriggerPreset
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._TriggerPreset) == null)
				{
					result = (this._TriggerPreset = new TArray<string>(base.NativePtr + (IntPtr)SSkillTrigger.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.TriggerPreset.CopyAssign(value);
			}
		}

		// Token: 0x17007B3A RID: 31546
		// (get) Token: 0x0602D38A RID: 185226 RVA: 0x00ABA6ED File Offset: 0x00AB88ED
		// (set) Token: 0x0602D38B RID: 185227 RVA: 0x00ABA701 File Offset: 0x00AB8901
		public unsafe string TriggerParams
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTrigger.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTrigger.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17007B3B RID: 31547
		// (get) Token: 0x0602D38C RID: 185228 RVA: 0x00ABA716 File Offset: 0x00AB8916
		// (set) Token: 0x0602D38D RID: 185229 RVA: 0x00ABA72A File Offset: 0x00AB892A
		public unsafe string TriggerFormula
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTrigger.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTrigger.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17007B3C RID: 31548
		// (get) Token: 0x0602D38E RID: 185230 RVA: 0x00ABA73F File Offset: 0x00AB893F
		// (set) Token: 0x0602D38F RID: 185231 RVA: 0x00ABA753 File Offset: 0x00AB8953
		public unsafe string TriggerTarget
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTrigger.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTrigger.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x17007B3D RID: 31549
		// (get) Token: 0x0602D390 RID: 185232 RVA: 0x00ABA768 File Offset: 0x00AB8968
		// (set) Token: 0x0602D391 RID: 185233 RVA: 0x00ABA77C File Offset: 0x00AB897C
		public unsafe string TriggerTargetSocket
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTrigger.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTrigger.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x0602D392 RID: 185234 RVA: 0x00ABA791 File Offset: 0x00AB8991
		public SSkillTrigger()
		{
		}

		// Token: 0x0602D393 RID: 185235 RVA: 0x00ABA799 File Offset: 0x00AB8999
		public SSkillTrigger(string TriggerType, TArray<string> TriggerPreset, string TriggerParams, string TriggerFormula, string TriggerTarget, string TriggerTargetSocket)
		{
			this.TriggerType = TriggerType;
			this.TriggerPreset = TriggerPreset;
			this.TriggerParams = TriggerParams;
			this.TriggerFormula = TriggerFormula;
			this.TriggerTarget = TriggerTarget;
			this.TriggerTargetSocket = TriggerTargetSocket;
		}

		// Token: 0x0602D394 RID: 185236 RVA: 0x00ABA7CE File Offset: 0x00AB89CE
		protected override IntPtr GetUStructPtr()
		{
			return SSkillTrigger.StaticStruct();
		}

		// Token: 0x0602D395 RID: 185237 RVA: 0x00ABA7DA File Offset: 0x00AB89DA
		[NullableContext(2)]
		public SSkillTrigger(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D396 RID: 185238 RVA: 0x00ABA7E4 File Offset: 0x00AB89E4
		public SSkillTrigger(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D397 RID: 185239 RVA: 0x00ABA7EF File Offset: 0x00AB89EF
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillTrigger(Pointer, false, true);
		}

		// Token: 0x0602D398 RID: 185240 RVA: 0x00ABA7F9 File Offset: 0x00AB89F9
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillTrigger(Pointer, MemoryOwner);
		}

		// Token: 0x040195A0 RID: 103840
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillTrigger.SSkillTrigger";

		// Token: 0x040195A1 RID: 103841
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040195A2 RID: 103842
		internal static int __PropertyOffset_0;

		// Token: 0x040195A3 RID: 103843
		internal static int __PropertyOffset_1;

		// Token: 0x040195A4 RID: 103844
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _TriggerPreset;

		// Token: 0x040195A5 RID: 103845
		internal static int __PropertyOffset_2;

		// Token: 0x040195A6 RID: 103846
		internal static int __PropertyOffset_3;

		// Token: 0x040195A7 RID: 103847
		internal static int __PropertyOffset_4;

		// Token: 0x040195A8 RID: 103848
		internal static int __PropertyOffset_5;
	}
}
