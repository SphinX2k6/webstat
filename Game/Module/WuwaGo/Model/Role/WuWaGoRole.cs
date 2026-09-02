using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Model.Role
{
	// Token: 0x02004ADE RID: 19166
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class WuWaGoRole : WuWaGoBaseUnit
	{
		// Token: 0x06031F7D RID: 204669 RVA: 0x00C82769 File Offset: 0x00C80969
		protected WuWaGoRole(EWuWaGoRoleType type, Vector coordinate, Rotator rotator) : base(coordinate, rotator)
		{
		}

		// Token: 0x06031F7E RID: 204670 RVA: 0x00C827A2 File Offset: 0x00C809A2
		[NullableContext(2)]
		protected override AActor GetActorRaw()
		{
			return this.ActorInner;
		}

		// Token: 0x17008541 RID: 34113
		// (get) Token: 0x06031F7F RID: 204671 RVA: 0x00C827AA File Offset: 0x00C809AA
		[Nullable(2)]
		public USkeletalMeshComponent Mesh
		{
			[NullableContext(2)]
			get
			{
				TsBaseCharacter actorInner = this.ActorInner;
				if (actorInner == null)
				{
					return null;
				}
				return actorInner.Mesh;
			}
		}

		// Token: 0x17008542 RID: 34114
		// (get) Token: 0x06031F80 RID: 204672 RVA: 0x00C827BD File Offset: 0x00C809BD
		[Nullable(2)]
		public UCharacterMovementComponent CharacterMovement
		{
			[NullableContext(2)]
			get
			{
				TsBaseCharacter actorInner = this.ActorInner;
				if (actorInner == null)
				{
					return null;
				}
				return actorInner.CharacterMovement;
			}
		}

		// Token: 0x06031F81 RID: 204673 RVA: 0x00C827D0 File Offset: 0x00C809D0
		[NullableContext(2)]
		public UKuroAnimInstanceChar GetAnimInstance()
		{
			TsBaseCharacter actorInner = this.ActorInner;
			object obj;
			if (actorInner == null)
			{
				obj = null;
			}
			else
			{
				USkeletalMeshComponent mesh = actorInner.Mesh;
				obj = ((mesh != null) ? mesh.GetAnimInstance() : null);
			}
			return obj as UKuroAnimInstanceChar;
		}

		// Token: 0x06031F82 RID: 204674 RVA: 0x00C827F5 File Offset: 0x00C809F5
		public void SetAnimRootMotionTranslationScale(float scale)
		{
			TsBaseCharacter actorInner = this.ActorInner;
			if (actorInner == null)
			{
				return;
			}
			actorInner.SetAnimRootMotionTranslationScale(scale);
		}

		// Token: 0x06031F83 RID: 204675 RVA: 0x00C82808 File Offset: 0x00C80A08
		public float GetCapsuleHalfHeight()
		{
			TsBaseCharacter actorInner = this.ActorInner;
			UCapsuleComponent ucapsuleComponent = (actorInner != null) ? actorInner.CapsuleComponent : null;
			if (ucapsuleComponent == null || !ucapsuleComponent.IsValid())
			{
				return 0f;
			}
			return ucapsuleComponent.GetScaledCapsuleHalfHeight();
		}

		// Token: 0x06031F84 RID: 204676 RVA: 0x00C8283F File Offset: 0x00C80A3F
		public bool GetActorEnableCollision()
		{
			TsBaseCharacter actorInner = this.ActorInner;
			return actorInner != null && actorInner.GetActorEnableCollision();
		}

		// Token: 0x06031F85 RID: 204677 RVA: 0x00C82852 File Offset: 0x00C80A52
		public void SetActorEnableCollision(bool enable)
		{
			TsBaseCharacter actorInner = this.ActorInner;
			if (actorInner == null)
			{
				return;
			}
			actorInner.SetActorEnableCollision(enable);
		}

		// Token: 0x06031F86 RID: 204678 RVA: 0x00C82865 File Offset: 0x00C80A65
		public void RegisterAttackHitListener(Action listener)
		{
			WuWaGoFactory.RegisterAttackHitListener(this.ActorInner, listener);
		}

		// Token: 0x06031F87 RID: 204679 RVA: 0x00C82873 File Offset: 0x00C80A73
		public void UnregisterAttackHitListener()
		{
			WuWaGoFactory.UnregisterAttackHitListener(this.ActorInner);
		}

		// Token: 0x17008543 RID: 34115
		// (get) Token: 0x06031F88 RID: 204680 RVA: 0x00C82880 File Offset: 0x00C80A80
		// (set) Token: 0x06031F89 RID: 204681 RVA: 0x00C82888 File Offset: 0x00C80A88
		public int Hp { get; private set; } = 1;

		// Token: 0x17008544 RID: 34116
		// (get) Token: 0x06031F8A RID: 204682 RVA: 0x00C82891 File Offset: 0x00C80A91
		// (set) Token: 0x06031F8B RID: 204683 RVA: 0x00C82899 File Offset: 0x00C80A99
		public bool IsClimbing { get; private set; }

		// Token: 0x17008545 RID: 34117
		// (get) Token: 0x06031F8C RID: 204684 RVA: 0x00C828A2 File Offset: 0x00C80AA2
		public bool IsDead
		{
			get
			{
				return this.Hp == 0;
			}
		}

		// Token: 0x17008546 RID: 34118
		// (get) Token: 0x06031F8D RID: 204685 RVA: 0x00C828AD File Offset: 0x00C80AAD
		public bool IsMonster
		{
			get
			{
				return this.Type > EWuWaGoRoleType.AircraftSoldiers;
			}
		}

		// Token: 0x17008547 RID: 34119
		// (get) Token: 0x06031F8E RID: 204686 RVA: 0x00C828B8 File Offset: 0x00C80AB8
		// (set) Token: 0x06031F8F RID: 204687 RVA: 0x00C828C0 File Offset: 0x00C80AC0
		public int StandGridId { get; private set; }

		// Token: 0x06031F90 RID: 204688 RVA: 0x00C828CC File Offset: 0x00C80ACC
		[NullableContext(0)]
		public UniTask<bool> Create()
		{
			WuWaGoRole.<Create>d__34 <Create>d__;
			<Create>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Create>d__.<>4__this = this;
			<Create>d__.<>1__state = -1;
			<Create>d__.<>t__builder.Start<WuWaGoRole.<Create>d__34>(ref <Create>d__);
			return <Create>d__.<>t__builder.Task;
		}

		// Token: 0x06031F91 RID: 204689 RVA: 0x00C82910 File Offset: 0x00C80B10
		public void Destroy()
		{
			this.ClearMaterialHandles();
			WuWaGoGrid gridById = ModelBase<WuWaGoModel>.Instance.GetGridById(this.StandGridId);
			if (gridById != null)
			{
				gridById.SetOccupiedUnit(null);
			}
			this.StandGridId = 0;
			this.NotifyStandGridChanged(gridById, null);
			TsBaseCharacter actorInner = this.ActorInner;
			if (actorInner != null && actorInner.IsValid())
			{
				WuWaGoFactory.DestroyRole(this.ActorInner);
			}
			this.ActorInner = null;
			this.StandGridChangedListeners.Clear();
			this.Hp = 1;
		}

		// Token: 0x06031F92 RID: 204690 RVA: 0x00C8298E File Offset: 0x00C80B8E
		public void AddMaterialHandle(int handle)
		{
			this.MaterialHandlesInner.Add(handle);
		}

		// Token: 0x06031F93 RID: 204691 RVA: 0x00C8299C File Offset: 0x00C80B9C
		public void ClearMaterialHandles()
		{
			if (this.MaterialHandlesInner.Count == 0)
			{
				return;
			}
			TsBaseCharacter actorInner = this.ActorInner;
			CharRenderingComponent charRenderingComponent = (actorInner != null) ? actorInner.CharRenderingComponent : null;
			if (charRenderingComponent != null && charRenderingComponent.IsValid())
			{
				foreach (int handle in this.MaterialHandlesInner)
				{
					charRenderingComponent.RemoveMaterialControllerData(handle);
				}
				foreach (KeyValuePair<int, double> keyValuePair in this.PetrifyMaterialHandles)
				{
					int num;
					double num2;
					keyValuePair.Deconstruct(out num, out num2);
					int handle2 = num;
					charRenderingComponent.RemoveMaterialControllerData(handle2);
				}
			}
			this.MaterialHandlesInner.Clear();
			this.PetrifyMaterialHandles.Clear();
		}

		// Token: 0x06031F94 RID: 204692 RVA: 0x00C82A88 File Offset: 0x00C80C88
		public UniTask ApplyPetrifyMaterial(BP_WuWaGo_C setting)
		{
			WuWaGoRole.<ApplyPetrifyMaterial>d__38 <ApplyPetrifyMaterial>d__;
			<ApplyPetrifyMaterial>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ApplyPetrifyMaterial>d__.<>4__this = this;
			<ApplyPetrifyMaterial>d__.setting = setting;
			<ApplyPetrifyMaterial>d__.<>1__state = -1;
			<ApplyPetrifyMaterial>d__.<>t__builder.Start<WuWaGoRole.<ApplyPetrifyMaterial>d__38>(ref <ApplyPetrifyMaterial>d__);
			return <ApplyPetrifyMaterial>d__.<>t__builder.Task;
		}

		// Token: 0x06031F95 RID: 204693 RVA: 0x00C82AD4 File Offset: 0x00C80CD4
		public UniTask PlayPetrifyDissolve()
		{
			WuWaGoRole.<PlayPetrifyDissolve>d__39 <PlayPetrifyDissolve>d__;
			<PlayPetrifyDissolve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayPetrifyDissolve>d__.<>4__this = this;
			<PlayPetrifyDissolve>d__.<>1__state = -1;
			<PlayPetrifyDissolve>d__.<>t__builder.Start<WuWaGoRole.<PlayPetrifyDissolve>d__39>(ref <PlayPetrifyDissolve>d__);
			return <PlayPetrifyDissolve>d__.<>t__builder.Task;
		}

		// Token: 0x06031F96 RID: 204694 RVA: 0x00C82B18 File Offset: 0x00C80D18
		private static UniTask DelayAsync(float ms)
		{
			WuWaGoRole.<DelayAsync>d__40 <DelayAsync>d__;
			<DelayAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DelayAsync>d__.ms = ms;
			<DelayAsync>d__.<>1__state = -1;
			<DelayAsync>d__.<>t__builder.Start<WuWaGoRole.<DelayAsync>d__40>(ref <DelayAsync>d__);
			return <DelayAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031F97 RID: 204695 RVA: 0x00C82B5B File Offset: 0x00C80D5B
		public override IRollbackCapture CaptureRollback()
		{
			return new RoleRollbackCapture<WuWaGoRole>(this);
		}

		// Token: 0x06031F98 RID: 204696 RVA: 0x00C82B64 File Offset: 0x00C80D64
		[NullableContext(2)]
		public void SetStandGrid(WuWaGoGrid grid, WuWaGoGrid prevGrid = null)
		{
			WuWaGoGrid wuWaGoGrid = prevGrid ?? ModelBase<WuWaGoModel>.Instance.GetGridById(this.StandGridId);
			int num = (grid != null) ? grid.Id : 0;
			if (this.StandGridId != num)
			{
				base.MarkRollbackDirty();
			}
			if (wuWaGoGrid != null && wuWaGoGrid != grid && wuWaGoGrid.OccupiedUnitId == this.Id)
			{
				wuWaGoGrid.SetOccupiedUnit(null);
			}
			this.StandGridId = num;
			if (grid != null)
			{
				base.SetCoordinate(grid.Coordinate);
				grid.SetOccupiedUnit(new int?(this.Id));
			}
			if (wuWaGoGrid != grid)
			{
				this.NotifyStandGridChanged(wuWaGoGrid, grid);
			}
		}

		// Token: 0x06031F99 RID: 204697 RVA: 0x00C82BFC File Offset: 0x00C80DFC
		public void SetHp(int value)
		{
			int num = Math.Max(0, value);
			if (this.Hp == num)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.Hp = num;
		}

		// Token: 0x06031F9A RID: 204698 RVA: 0x00C82C28 File Offset: 0x00C80E28
		public void SetIsClimbing(bool value)
		{
			if (this.IsClimbing == value)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.IsClimbing = value;
		}

		// Token: 0x06031F9B RID: 204699 RVA: 0x00C82C41 File Offset: 0x00C80E41
		public void AddStandGridChangedListener(WuWaGoRoleStandGridChangedListener listener)
		{
			this.StandGridChangedListeners.Add(listener);
		}

		// Token: 0x06031F9C RID: 204700 RVA: 0x00C82C50 File Offset: 0x00C80E50
		public void RemoveStandGridChangedListener(WuWaGoRoleStandGridChangedListener listener)
		{
			this.StandGridChangedListeners.Remove(listener);
		}

		// Token: 0x06031F9D RID: 204701 RVA: 0x00C82C60 File Offset: 0x00C80E60
		[NullableContext(2)]
		private void NotifyStandGridChanged(WuWaGoGrid prevGrid, WuWaGoGrid currentGrid)
		{
			foreach (WuWaGoRoleStandGridChangedListener wuWaGoRoleStandGridChangedListener in this.StandGridChangedListeners)
			{
				wuWaGoRoleStandGridChangedListener(this, prevGrid, currentGrid);
			}
		}

		// Token: 0x0401D3D1 RID: 119761
		private readonly HashSet<WuWaGoRoleStandGridChangedListener> StandGridChangedListeners = new HashSet<WuWaGoRoleStandGridChangedListener>();

		// Token: 0x0401D3D2 RID: 119762
		private readonly List<int> MaterialHandlesInner = new List<int>();

		// Token: 0x0401D3D3 RID: 119763
		private readonly Dictionary<int, double> PetrifyMaterialHandles = new Dictionary<int, double>();

		// Token: 0x0401D3D4 RID: 119764
		[Nullable(2)]
		protected TsBaseCharacter ActorInner;

		// Token: 0x0401D3D8 RID: 119768
		public readonly EWuWaGoRoleType Type = type;
	}
}
