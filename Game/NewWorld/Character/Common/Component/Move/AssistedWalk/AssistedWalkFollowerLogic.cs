using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.GameplayABP;
using AkiClient.Game.Aki.Data.Level.AssistedWalk;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AttachMove;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move.AssistedWalk
{
	// Token: 0x02004945 RID: 18757
	[NullableContext(2)]
	[Nullable(0)]
	public class AssistedWalkFollowerLogic : AttachMoveLogic
	{
		// Token: 0x170083AA RID: 33706
		// (get) Token: 0x060310B1 RID: 200881 RVA: 0x00C3136A File Offset: 0x00C2F56A
		// (set) Token: 0x060310B2 RID: 200882 RVA: 0x00C31377 File Offset: 0x00C2F577
		protected new AssistedWalkParams Params
		{
			get
			{
				return this.Params as AssistedWalkParams;
			}
			set
			{
				this.Params = value;
			}
		}

		// Token: 0x060310B3 RID: 200883 RVA: 0x00C31380 File Offset: 0x00C2F580
		public override bool IsMoving()
		{
			return this.InState;
		}

		// Token: 0x060310B4 RID: 200884 RVA: 0x00C31388 File Offset: 0x00C2F588
		public override void StopMove()
		{
			Action exitCallback = this.ExitCallback;
			this.ExitCallback = null;
			if (!this.InState)
			{
				this.ClearFollowerAssistedWalkTag();
				this.ClearFollowerComponents();
				if (exitCallback != null)
				{
					exitCallback();
				}
				return;
			}
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.ClearInput(false, true);
			}
			if (this.ArePartnerComponentsAlive())
			{
				this.ResetFollowerState();
				this.WriteFollowerAnimLogicParams(false, true);
			}
			this.AnimInstance = null;
			Singleton<AssistedWalkUtils>.Instance.RestoreSightLockMode(this.ActorComp, this.LastSightLockMode);
			CharacterCustomActionComponent leaderActionComp = this.LeaderActionComp;
			if (leaderActionComp != null)
			{
				leaderActionComp.AddCustomSetPlayerControl(false, null);
			}
			this.LeaderActionComp = null;
			this.ClearFollowerAssistedWalkTag();
			base.StopMove();
			this.ClearFollowerComponents();
			if (exitCallback != null)
			{
				exitCallback();
			}
		}

		// Token: 0x060310B5 RID: 200885 RVA: 0x00C3143C File Offset: 0x00C2F63C
		public override void Dispose()
		{
			this.StopMove();
		}

		// Token: 0x060310B6 RID: 200886 RVA: 0x00C31444 File Offset: 0x00C2F644
		[NullableContext(1)]
		public void StartHelpedAssistedWalkWithData(Entity entity, CharacterActorComponent leader, BP_AssistedWalkConfig_C data, [Nullable(2)] Action endCallback = null, bool waitAnim = true)
		{
			if (this.InState)
			{
				this.StopMove();
			}
			this.InitComponents(entity);
			if (this.MoveComp == null || this.AnimComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[AttachMove][AssistedWalk][Follower] Start 组件无效";
				string item = "PbDataId";
				CharacterActorComponent actorComp = this.ActorComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			base.PrepareAttachMove(entity, data, endCallback);
			if (!this.InState)
			{
				return;
			}
			this.Params = new AssistedWalkParams(data);
			base.AddTags(this.TagComp, this.Params.GameplayTagList);
			this.AnimInstance = (this.AnimComp.MainAnimInstance as UKuroAnimInstanceChar);
			this.WriteFollowerAnimLogicParams(true, waitAnim);
			this.ApplyFollowerEnterState(leader);
			Entity entity2 = leader.Entity;
			this.LeaderActionComp = ((entity2 != null) ? entity2.GetComponent<CharacterCustomActionComponent>() : null);
			this.AssistedWalkTagId = GameplayTagDefine.EGameplayTagId["角色.Common.地区运动状态.搀扶行走.被搀扶"];
			base.SetOnlyTag(this.TagComp, this.AssistedWalkTagId, true, "[AttachMove][AssistedWalk][Follower] Start");
			this.LastSightLockMode = Singleton<AssistedWalkUtils>.Instance.SaveAndDisableSightLockMode(this.ActorComp);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Movement;
			ELogAuthor author2 = ELogAuthor.CWZ;
			string message2 = "[AttachMove][AssistedWalk][Follower] StartMove";
			string item2 = "PbDataId";
			CharacterActorComponent actorComp2 = this.ActorComp;
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (actorComp2 != null) ? new int?(actorComp2.CreatureData.GetPbDataId()) : null);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}

		// Token: 0x060310B7 RID: 200887 RVA: 0x00C315CC File Offset: 0x00C2F7CC
		[NullableContext(1)]
		private void ApplyFollowerEnterState(CharacterActorComponent leader)
		{
			if (leader == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[AttachMove][AssistedWalk][Follower] ApplyFollowerEnterState 缺少 Leader";
				string item = "PbDataId";
				CharacterActorComponent actorComp = this.ActorComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			CharacterActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 != null)
			{
				BaseMoveComponent moveComp = actorComp2.MoveComp;
				if (moveComp != null)
				{
					moveComp.MoveController.EnableAutoSync(30, 0.01f);
				}
			}
			this.MoveComp.IsRegionMoveMode = true;
			this.AnimComp.DisableHumanIk = true;
			CharacterLinkedAnimInstComponent component = this.Entity.GetComponent<CharacterLinkedAnimInstComponent>();
			if (component == null)
			{
				return;
			}
			component.SyncLinkGameplayAnimBlueprint(EGameplayABPType.AssistedWalk);
		}

		// Token: 0x060310B8 RID: 200888 RVA: 0x00C31684 File Offset: 0x00C2F884
		private void ResetFollowerState()
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				BaseMoveComponent moveComp = actorComp.MoveComp;
				if (moveComp != null)
				{
					moveComp.MoveController.DisableAutoSync();
				}
			}
			if (this.MoveComp != null)
			{
				this.MoveComp.IsRegionMoveMode = false;
			}
			if (this.AnimComp != null)
			{
				this.AnimComp.DisableHumanIk = false;
			}
			Entity entity = this.Entity;
			CharacterLinkedAnimInstComponent characterLinkedAnimInstComponent = (entity != null) ? entity.GetComponent<CharacterLinkedAnimInstComponent>() : null;
			if (characterLinkedAnimInstComponent == null)
			{
				return;
			}
			characterLinkedAnimInstComponent.SyncLinkGameplayAnimBlueprint(EGameplayABPType.None);
		}

		// Token: 0x060310B9 RID: 200889 RVA: 0x00C316F8 File Offset: 0x00C2F8F8
		private void WriteFollowerAnimLogicParams(bool entering, bool waitAnim = true)
		{
			UKuroAnimInstanceChar animInstance = this.AnimInstance;
			UAbpLogicParams uabpLogicParams = (animInstance != null) ? animInstance.LogicParams : null;
			if (uabpLogicParams == null)
			{
				return;
			}
			uabpLogicParams.bHelpedAssistedWalk = entering;
			uabpLogicParams.bSkipEnterAssistedWalkAnim = (entering && !waitAnim);
			uabpLogicParams.AssistedWalkAnimRate = 1f;
			uabpLogicParams.bInAssistedWalking = false;
		}

		// Token: 0x060310BA RID: 200890 RVA: 0x00C31748 File Offset: 0x00C2F948
		[NullableContext(1)]
		private void InitComponents(Entity entity)
		{
			this.Entity = entity;
			this.ActorComp = entity.GetComponent<CharacterActorComponent>();
			this.MoveComp = entity.GetComponent<BaseMoveComponent>();
			this.AnimComp = entity.GetComponent<CharacterAnimationComponent>();
			this.TagComp = entity.GetComponent<BaseTagComponent>();
			this.UeMovementComp = entity.GetComponent<UeMovementTickManageComponent>();
		}

		// Token: 0x060310BB RID: 200891 RVA: 0x00C31798 File Offset: 0x00C2F998
		private void ClearFollowerAssistedWalkTag()
		{
			if (this.AssistedWalkTagId == 0)
			{
				return;
			}
			base.SetOnlyTag(this.TagComp, this.AssistedWalkTagId, false, "[AttachMove][AssistedWalk][Follower] StopMove");
			this.AssistedWalkTagId = 0;
		}

		// Token: 0x060310BC RID: 200892 RVA: 0x00C317C2 File Offset: 0x00C2F9C2
		private void ClearFollowerComponents()
		{
			this.Entity = null;
			this.ActorComp = null;
			this.MoveComp = null;
			this.AnimComp = null;
			this.UeMovementComp = null;
			this.AnimInstance = null;
			this.LeaderActionComp = null;
		}

		// Token: 0x060310BD RID: 200893 RVA: 0x00C317F8 File Offset: 0x00C2F9F8
		private bool ArePartnerComponentsAlive()
		{
			AssistedWalkUtils instance = Singleton<AssistedWalkUtils>.Instance;
			string logTag = "[AttachMove][AssistedWalk][Follower] 兄弟组件已销毁，跳过状态恢复";
			CharacterActorComponent actorComp = this.ActorComp;
			bool[] array = new bool[4];
			int num = 0;
			UeMovementTickManageComponent ueMovementComp = this.UeMovementComp;
			array[num] = (ueMovementComp == null || ueMovementComp.Valid);
			int num2 = 1;
			BaseMoveComponent moveComp = this.MoveComp;
			array[num2] = (moveComp == null || moveComp.Valid);
			int num3 = 2;
			CharacterAnimationComponent animComp = this.AnimComp;
			array[num3] = (animComp == null || animComp.Valid);
			int num4 = 3;
			BaseTagComponent tagComp = this.TagComp;
			array[num4] = (tagComp == null || tagComp.Valid);
			return instance.ArePartnerComponentsAlive(logTag, actorComp, array);
		}

		// Token: 0x0401C3CC RID: 115660
		private Entity Entity;

		// Token: 0x0401C3CD RID: 115661
		private CharacterActorComponent ActorComp;

		// Token: 0x0401C3CE RID: 115662
		private BaseMoveComponent MoveComp;

		// Token: 0x0401C3CF RID: 115663
		private CharacterAnimationComponent AnimComp;

		// Token: 0x0401C3D0 RID: 115664
		private UeMovementTickManageComponent UeMovementComp;

		// Token: 0x0401C3D1 RID: 115665
		private UKuroAnimInstanceChar AnimInstance;

		// Token: 0x0401C3D2 RID: 115666
		private int AssistedWalkTagId;

		// Token: 0x0401C3D3 RID: 115667
		private CharacterCustomActionComponent LeaderActionComp;

		// Token: 0x0401C3D4 RID: 115668
		private SightLockMode LastSightLockMode;
	}
}
