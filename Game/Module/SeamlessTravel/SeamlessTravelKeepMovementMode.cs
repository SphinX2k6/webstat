using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.Module.SeamlessTravel
{
	// Token: 0x02005005 RID: 20485
	[NullableContext(2)]
	[Nullable(0)]
	public class SeamlessTravelKeepMovementMode
	{
		// Token: 0x17008ABD RID: 35517
		// (get) Token: 0x06034CDA RID: 216282 RVA: 0x00D409D0 File Offset: 0x00D3EBD0
		public bool IsInit
		{
			get
			{
				return this.IsInitInternal;
			}
		}

		// Token: 0x17008ABE RID: 35518
		// (get) Token: 0x06034CDB RID: 216283 RVA: 0x00D409D8 File Offset: 0x00D3EBD8
		public bool IsActive
		{
			get
			{
				return this.IsActiveInternal;
			}
		}

		// Token: 0x17008ABF RID: 35519
		// (get) Token: 0x06034CDC RID: 216284 RVA: 0x00D409E0 File Offset: 0x00D3EBE0
		public EMovementMode? TargetMovementMode
		{
			get
			{
				return this.TargetMovementModeInternal;
			}
		}

		// Token: 0x17008AC0 RID: 35520
		// (get) Token: 0x06034CDD RID: 216285 RVA: 0x00D409E8 File Offset: 0x00D3EBE8
		public byte? TargetCustomMode
		{
			get
			{
				return this.TargetCustomModeInternal;
			}
		}

		// Token: 0x06034CDE RID: 216286 RVA: 0x00D409F0 File Offset: 0x00D3EBF0
		public void SetInitDataWithTargetMode(EMovementMode targetMovementMode, byte? targetCustomMode = null)
		{
			this.TargetMovementModeInternal = new EMovementMode?(targetMovementMode);
			this.TargetCustomModeInternal = targetCustomMode;
		}

		// Token: 0x06034CDF RID: 216287 RVA: 0x00D40A08 File Offset: 0x00D3EC08
		[NullableContext(0)]
		public static ValueTuple<EMovementMode, byte>? GetCurrentKeepableMovementMode([Nullable(1)] SeamlessTravelContext context)
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
				return null;
			}
			KeepMovementStateFeatures keepMovementStateFeatures = context.KeepMovementStateFeatures;
			if (keepMovementStateFeatures != null && keepMovementStateFeatures.KeepSoar)
			{
				ValueTuple<EMovementMode, int>? movementModeByConfigState = SeamlessTravelKeepMovementMode.GetMovementModeByConfigState(EKeepMovementState.Soar);
				if (movementModeByConfigState != null && tenumAsByte == movementModeByConfigState.Value.Item1)
				{
					byte? b2 = b;
					int? num = (b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null;
					int item = movementModeByConfigState.Value.Item2;
					if (num.GetValueOrDefault() == item & num != null)
					{
						return new ValueTuple<EMovementMode, byte>?(new ValueTuple<EMovementMode, byte>(tenumAsByte.Value, b.Value));
					}
				}
			}
			KeepMovementStateFeatures keepMovementStateFeatures2 = context.KeepMovementStateFeatures;
			if (keepMovementStateFeatures2 != null && keepMovementStateFeatures2.KeepKite)
			{
				ValueTuple<EMovementMode, int>? movementModeByConfigState2 = SeamlessTravelKeepMovementMode.GetMovementModeByConfigState(EKeepMovementState.Kite);
				if (movementModeByConfigState2 != null && tenumAsByte == movementModeByConfigState2.Value.Item1)
				{
					byte? b2 = b;
					int? num = (b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null;
					int item = movementModeByConfigState2.Value.Item2;
					if (num.GetValueOrDefault() == item & num != null)
					{
						return new ValueTuple<EMovementMode, byte>?(new ValueTuple<EMovementMode, byte>(tenumAsByte.Value, b.Value));
					}
				}
			}
			return null;
		}

		// Token: 0x06034CE0 RID: 216288 RVA: 0x00D40C1E File Offset: 0x00D3EE1E
		[NullableContext(0)]
		public static ValueTuple<EMovementMode, int>? GetMovementModeByConfigState(EKeepMovementState keepMovementState)
		{
			return new ValueTuple<EMovementMode, int>?(SeamlessTravelKeepMovementMode.configStateToMovementMode[keepMovementState]);
		}

		// Token: 0x06034CE1 RID: 216289 RVA: 0x00D40C30 File Offset: 0x00D3EE30
		[NullableContext(1)]
		public void Init(SeamlessTravelContext context, [Nullable(2)] Action<bool> callback = null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.ZYL, "[无缝传送KeepMovementMode] 初始化(开始)", default(ReadOnlySpan<ValueTuple<string, object>>));
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			this.ActorComp = ((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null);
			if (this.ActorComp == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Teleport;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[无缝传送KeepMovementMode] 初始化失败，无效的ActorComp";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActorName", Global.BaseCharacter);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			if (this.IsInit)
			{
				if (callback != null)
				{
					callback(true);
				}
				return;
			}
			this.Context = context;
			if (this.Context == null)
			{
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			this.IsInitInternal = true;
			if (callback != null)
			{
				callback(true);
			}
		}

		// Token: 0x06034CE2 RID: 216290 RVA: 0x00D40CF2 File Offset: 0x00D3EEF2
		public void Tick(float delta)
		{
			this.CheckAndKeepMoveState();
		}

		// Token: 0x06034CE3 RID: 216291 RVA: 0x00D40CFC File Offset: 0x00D3EEFC
		public void CheckAndKeepMoveState()
		{
			if (!this.IsInit || !this.IsActive)
			{
				return;
			}
			if (this.TargetMovementMode == null)
			{
				return;
			}
			CharacterActorComponent actorComp = this.ActorComp;
			UCharacterMovementComponent ucharacterMovementComponent;
			if (actorComp == null)
			{
				ucharacterMovementComponent = null;
			}
			else
			{
				BaseMoveComponent moveComp = actorComp.MoveComp;
				ucharacterMovementComponent = ((moveComp != null) ? moveComp.CharacterMovement : null);
			}
			UCharacterMovementComponent ucharacterMovementComponent2 = ucharacterMovementComponent;
			if (ucharacterMovementComponent2 == null)
			{
				return;
			}
			TEnumAsByte<EMovementMode> movementMode = ucharacterMovementComponent2.MovementMode;
			byte customMovementMode = ucharacterMovementComponent2.CustomMovementMode;
			TEnumAsByte<EMovementMode> left = movementMode;
			EMovementMode? targetMovementMode = this.TargetMovementMode;
			if (!(left != ((targetMovementMode != null) ? new TEnumAsByte<EMovementMode>?(targetMovementMode.GetValueOrDefault()) : null)))
			{
				if (this.TargetCustomMode == null)
				{
					return;
				}
				int num = (int)customMovementMode;
				byte? targetCustomMode = this.TargetCustomMode;
				int? num2 = (targetCustomMode != null) ? new int?((int)targetCustomMode.GetValueOrDefault()) : null;
				if (num == num2.GetValueOrDefault() & num2 != null)
				{
					return;
				}
			}
			this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = this.TargetMovementMode.Value,
				CustomMode = this.TargetCustomMode.GetValueOrDefault(),
				Context = "[SeamlessTravelKeepMovementMode.CheckAndKeepMoveState]"
			});
		}

		// Token: 0x06034CE4 RID: 216292 RVA: 0x00D40E48 File Offset: 0x00D3F048
		public void Destroy()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.ZYL, "[无缝传送KeepMovementMode] 清理", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInitInternal = false;
			this.ActorComp = null;
			this.Context = null;
		}

		// Token: 0x06034CE5 RID: 216293 RVA: 0x00D40E8C File Offset: 0x00D3F08C
		public void AppearEffect(Action<bool> callback = null)
		{
			if (!this.IsInit)
			{
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			if (this.IsActive)
			{
				if (callback != null)
				{
					callback(true);
				}
				return;
			}
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null || !actorComp.Actor.IsValid())
			{
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.ZYL, "[无缝传送KeepMovementMode] 开启效果", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsActiveInternal = true;
			if (callback != null)
			{
				callback(true);
			}
		}

		// Token: 0x06034CE6 RID: 216294 RVA: 0x00D40F18 File Offset: 0x00D3F118
		public void DisappearEffect(Action<bool> callback = null)
		{
			if (!this.IsInit)
			{
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			if (!this.IsActive)
			{
				if (callback != null)
				{
					callback(true);
				}
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.ZYL, "[无缝传送KeepMovementMode] 关闭效果", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsActiveInternal = false;
			if (callback != null)
			{
				callback(true);
			}
		}

		// Token: 0x06034CE8 RID: 216296 RVA: 0x00D40F83 File Offset: 0x00D3F183
		// Note: this type is marked as 'beforefieldinit'.
		static SeamlessTravelKeepMovementMode()
		{
			Dictionary<EKeepMovementState, ValueTuple<EMovementMode, int>> dictionary = new Dictionary<EKeepMovementState, ValueTuple<EMovementMode, int>>();
			dictionary[EKeepMovementState.Kite] = new ValueTuple<EMovementMode, int>(EMovementMode.MOVE_Custom, 10);
			dictionary[EKeepMovementState.Soar] = new ValueTuple<EMovementMode, int>(EMovementMode.MOVE_Custom, 7);
			SeamlessTravelKeepMovementMode.configStateToMovementMode = dictionary;
		}

		// Token: 0x0401E6BD RID: 124605
		[Nullable(new byte[]
		{
			1,
			0
		})]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EKeepMovementState, ValueTuple<EMovementMode, int>> configStateToMovementMode;

		// Token: 0x0401E6BE RID: 124606
		private CharacterActorComponent ActorComp;

		// Token: 0x0401E6BF RID: 124607
		private SeamlessTravelContext Context;

		// Token: 0x0401E6C0 RID: 124608
		private EMovementMode? TargetMovementModeInternal;

		// Token: 0x0401E6C1 RID: 124609
		private byte? TargetCustomModeInternal;

		// Token: 0x0401E6C2 RID: 124610
		private bool IsInitInternal;

		// Token: 0x0401E6C3 RID: 124611
		private bool IsActiveInternal;
	}
}
