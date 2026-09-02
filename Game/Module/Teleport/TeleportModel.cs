using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.SeamlessTravel;
using UnrealEngine;

namespace CSharpScript.Game.Module.Teleport
{
	// Token: 0x02004EEF RID: 20207
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class TeleportModel : ModelBase<TeleportModel>
	{
		// Token: 0x170089F7 RID: 35319
		// (get) Token: 0x06034364 RID: 213860 RVA: 0x00D0E595 File Offset: 0x00D0C795
		public TeleportContext TeleportContext
		{
			get
			{
				if (this.TeleportContextQueue.Count == 0)
				{
					return null;
				}
				return this.TeleportContextQueue[this.TeleportContextQueue.Count - 1];
			}
		}

		// Token: 0x170089F8 RID: 35320
		// (get) Token: 0x06034365 RID: 213861 RVA: 0x00D0E5BE File Offset: 0x00D0C7BE
		public bool IsTeleport
		{
			get
			{
				return this.TeleportContextQueue.Count > 0;
			}
		}

		// Token: 0x170089F9 RID: 35321
		// (get) Token: 0x06034366 RID: 213862 RVA: 0x00D0E5CE File Offset: 0x00D0C7CE
		public global::Vector StartPosition
		{
			get
			{
				return this.StartPositionInternal;
			}
		}

		// Token: 0x170089FA RID: 35322
		// (get) Token: 0x06034367 RID: 213863 RVA: 0x00D0E5D6 File Offset: 0x00D0C7D6
		public Rotator StartRotation
		{
			get
			{
				return this.StartRotationInternal;
			}
		}

		// Token: 0x170089FB RID: 35323
		// (get) Token: 0x06034368 RID: 213864 RVA: 0x00D0E5DE File Offset: 0x00D0C7DE
		public global::Vector StartGravityDirect
		{
			get
			{
				return this.StartGravityDirectInternal;
			}
		}

		// Token: 0x170089FC RID: 35324
		// (get) Token: 0x06034369 RID: 213865 RVA: 0x00D0E5E6 File Offset: 0x00D0C7E6
		public global::Vector TargetPosition
		{
			get
			{
				return this.TargetPositionInternal;
			}
		}

		// Token: 0x170089FD RID: 35325
		// (get) Token: 0x0603436A RID: 213866 RVA: 0x00D0E5EE File Offset: 0x00D0C7EE
		public Rotator TargetRotation
		{
			get
			{
				return this.TargetRotationInternal;
			}
		}

		// Token: 0x170089FE RID: 35326
		// (get) Token: 0x0603436B RID: 213867 RVA: 0x00D0E5F6 File Offset: 0x00D0C7F6
		public global::Vector TargetGravityDirect
		{
			get
			{
				return this.TargetGravityDirectInternal;
			}
		}

		// Token: 0x170089FF RID: 35327
		// (get) Token: 0x0603436C RID: 213868 RVA: 0x00D0E5FE File Offset: 0x00D0C7FE
		public Rotator CameraStartRotation
		{
			get
			{
				return this.CameraStartRotationInternal;
			}
		}

		// Token: 0x17008A00 RID: 35328
		// (get) Token: 0x0603436D RID: 213869 RVA: 0x00D0E606 File Offset: 0x00D0C806
		// (set) Token: 0x0603436E RID: 213870 RVA: 0x00D0E610 File Offset: 0x00D0C810
		public bool IsSkillBlocked
		{
			get
			{
				return this.IsSkillBlockedInternal;
			}
			set
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.TeleportMisc;
				ELogAuthor author = ELogAuthor.CK;
				string message = "设置是否禁止释放技能";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IsSkillBlocked", value);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.IsSkillBlockedInternal = value;
			}
		}

		// Token: 0x0603436F RID: 213871 RVA: 0x00D0E654 File Offset: 0x00D0C854
		[NullableContext(1)]
		public unsafe void SetAllowTeleportByUi(bool allowTeleport, string reason)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.TeleportMisc;
			ELogAuthor author = ELogAuthor.CK;
			string message = "传送: 设置是否允许UI发起传送";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AllowTeleport", allowTeleport);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.AllowTeleportInternal = allowTeleport;
		}

		// Token: 0x17008A01 RID: 35329
		// (get) Token: 0x06034370 RID: 213872 RVA: 0x00D0E6C3 File Offset: 0x00D0C8C3
		public bool AllowTeleportByUi
		{
			get
			{
				return this.AllowTeleportInternal;
			}
		}

		// Token: 0x06034371 RID: 213873 RVA: 0x00D0E6CC File Offset: 0x00D0C8CC
		protected override bool OnInit()
		{
			this.StartPositionInternal = global::Vector.Create();
			this.TargetPositionInternal = global::Vector.Create();
			this.StartRotationInternal = Rotator.Create();
			this.CameraStartRotationInternal = Rotator.Create();
			this.TargetRotationInternal = Rotator.Create();
			this.StartGravityDirectInternal = global::Vector.Create();
			this.TargetGravityDirectInternal = global::Vector.Create();
			return true;
		}

		// Token: 0x06034372 RID: 213874 RVA: 0x00D0E727 File Offset: 0x00D0C927
		protected override bool OnClear()
		{
			this.StartPositionInternal = null;
			this.TargetPositionInternal = null;
			this.StartRotationInternal = null;
			this.CameraStartRotationInternal = null;
			this.TargetRotationInternal = null;
			this.StartGravityDirectInternal = null;
			this.TargetGravityDirectInternal = null;
			this.Cache.Clear();
			return true;
		}

		// Token: 0x06034373 RID: 213875 RVA: 0x00D0E766 File Offset: 0x00D0C966
		protected override bool OnLeaveLevel()
		{
			this.SetAllowTeleportByUi(true, "OnLeaveLevel");
			return true;
		}

		// Token: 0x06034374 RID: 213876 RVA: 0x00D0E778 File Offset: 0x00D0C978
		public bool GetIsKeepingCurrentMovementMode()
		{
			if (this.TeleportContext != null && this.TeleportContext.IsInSeamlessTeleport)
			{
				SeamlessTravelKeepMovementMode keepMovementMode = this.TeleportContext.KeepMovementMode;
				if (keepMovementMode != null && keepMovementMode.IsActive)
				{
					TsBaseCharacter baseCharacter = Global.BaseCharacter;
					object obj;
					if (baseCharacter == null)
					{
						obj = null;
					}
					else
					{
						CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
						if (characterActorComponent == null)
						{
							obj = null;
						}
						else
						{
							BaseMoveComponent moveComp = characterActorComponent.MoveComp;
							obj = ((moveComp != null) ? moveComp.CharacterMovement : null);
						}
					}
					object obj2 = obj;
					TEnumAsByte<EMovementMode>? tenumAsByte = (obj2 != null) ? new TEnumAsByte<EMovementMode>?(obj2.MovementMode) : null;
					byte? b = (obj2 != null) ? new byte?(obj2.CustomMovementMode) : null;
					if (tenumAsByte == null || b == null)
					{
						return false;
					}
					EMovementMode? targetMovementMode = this.TeleportContext.KeepMovementMode.TargetMovementMode;
					if (((targetMovementMode != null) ? new TEnumAsByte<EMovementMode>?(targetMovementMode.GetValueOrDefault()) : null) == tenumAsByte)
					{
						byte? b2 = this.TeleportContext.KeepMovementMode.TargetCustomMode;
						int? num = (b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null;
						b2 = b;
						int? num2 = (b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null;
						return num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null);
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x06034375 RID: 213877 RVA: 0x00D0E918 File Offset: 0x00D0CB18
		[NullableContext(1)]
		public unsafe TeleportContext CreateContext(ITeleportContext contextParams)
		{
			if (this.TeleportContextQueue.Count > 0)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Teleport, ELogAuthor.CK, "传送: 尝试在传送过程中再次发起传送, 需要关注", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			TeleportContext teleportContext = TeleportContext.CreateContext(contextParams);
			this.TeleportContextQueue.Add(teleportContext);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.TeleportMisc;
			ELogAuthor author = ELogAuthor.CK;
			string message = "创建上下文";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TeleportContextId", teleportContext.TeleportContextId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ClientReason", teleportContext.ClientReason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ServerReason", teleportContext.ServerReason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return teleportContext;
		}

		// Token: 0x06034376 RID: 213878 RVA: 0x00D0E9F0 File Offset: 0x00D0CBF0
		[NullableContext(1)]
		public void RemoveContext(TeleportContext context)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.TeleportMisc;
			ELogAuthor author = ELogAuthor.CK;
			string message = "移除上下文";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TeleportContextId", context.TeleportContextId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			for (int i = 0; i < this.TeleportContextQueue.Count; i++)
			{
				if (this.TeleportContextQueue[i] == context)
				{
					this.TeleportContextQueue.RemoveAt(i);
					return;
				}
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.TeleportMisc;
			ELogAuthor author2 = ELogAuthor.CK;
			string message2 = "移除上下文失败";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("TeleportContextId", context.TeleportContextId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}

		// Token: 0x06034377 RID: 213879 RVA: 0x00D0EA98 File Offset: 0x00D0CC98
		public unsafe ITeleportTransitionType ParseTransitionConfig(int id)
		{
			ITeleportTransitionType result;
			if (this.Cache.TryGetValue(id, out result))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.TeleportMisc;
				ELogAuthor author = ELogAuthor.CK;
				string message = "传送过渡配置缓存命中, 直接读取缓存结果";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", id);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return result;
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.TeleportMisc;
			ELogAuthor author2 = ELogAuthor.CK;
			string message2 = "传送过渡配置JSON解析";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ConfigId", id);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			TeleportTransitionConfig? config = ConfigTeleportTransitionConfigById.GetConfig(id, true);
			if (config == null)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.TeleportMisc;
				ELogAuthor author3 = ELogAuthor.CK;
				string message3 = "传送过渡配置查询失败: 未找到配置";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("ConfigId", id);
				instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return null;
			}
			string data = config.Value.Data;
			if (data == null)
			{
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.TeleportMisc;
				ELogAuthor author4 = ELogAuthor.CK;
				string message4 = "传送过渡配置查询失败: Data为空";
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("ConfigId", id);
				instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				return null;
			}
			ITeleportTransitionType result2;
			try
			{
				ITeleportTransitionType teleportTransitionType = Json.Parse<ITeleportTransitionType>(data, null);
				this.Cache[id] = teleportTransitionType;
				result2 = teleportTransitionType;
			}
			catch (Exception ex)
			{
				global::Log instance5 = Singleton<global::Log>.Instance;
				ELogModule module5 = ELogModule.TeleportMisc;
				ELogAuthor author5 = ELogAuthor.CK;
				string message5 = "传送过渡配置JSON解析失败";
				Exception error = ex;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Error", ex.Message);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ConfigId", id);
				instance5.ErrorWithStack(module5, author5, message5, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				result2 = null;
			}
			return result2;
		}

		// Token: 0x0401E22D RID: 123437
		[Nullable(1)]
		private readonly List<TeleportContext> TeleportContextQueue = new List<TeleportContext>();

		// Token: 0x0401E22E RID: 123438
		[Nullable(1)]
		private readonly Dictionary<int, ITeleportTransitionType> Cache = new Dictionary<int, ITeleportTransitionType>();

		// Token: 0x0401E22F RID: 123439
		private global::Vector StartPositionInternal;

		// Token: 0x0401E230 RID: 123440
		private Rotator StartRotationInternal;

		// Token: 0x0401E231 RID: 123441
		private global::Vector StartGravityDirectInternal;

		// Token: 0x0401E232 RID: 123442
		private global::Vector TargetPositionInternal;

		// Token: 0x0401E233 RID: 123443
		private Rotator TargetRotationInternal;

		// Token: 0x0401E234 RID: 123444
		private global::Vector TargetGravityDirectInternal;

		// Token: 0x0401E235 RID: 123445
		private Rotator CameraStartRotationInternal;

		// Token: 0x0401E236 RID: 123446
		private bool IsSkillBlockedInternal;

		// Token: 0x0401E237 RID: 123447
		private bool AllowTeleportInternal = true;
	}
}
