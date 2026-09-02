using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052F2 RID: 21234
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class QuickHackBaseOnScreenTargetSelector : QuickHackTargetSelector
	{
		// Token: 0x06036368 RID: 222056 RVA: 0x00DA9A0E File Offset: 0x00DA7C0E
		public override void Init(int selectRange, int selectScreenRadius)
		{
			base.Init(selectRange, selectScreenRadius);
			this.OnInit();
		}

		// Token: 0x06036369 RID: 222057 RVA: 0x00DA9A1E File Offset: 0x00DA7C1E
		public override void Clear()
		{
			this.EntitiesInRange.Clear();
			this.TargetSet.Clear();
			this.LockTargetInfo = null;
			this.OnScreenTargetInfo = null;
			this.LockIgnoreCheckOnScreen = false;
		}

		// Token: 0x0603636A RID: 222058 RVA: 0x00DA9A4C File Offset: 0x00DA7C4C
		public override bool UpdateTargetInfo(float delta)
		{
			if (this.LockTargetInfo == null)
			{
				this.LockTargetInfo = new QuickHackLockTargetInfo
				{
					HackType = null,
					Targets = this.TargetSet
				};
			}
			if (this.OnScreenTargetInfo == null)
			{
				this.OnScreenTargetInfo = new QuickHackOnScreenTargetInfo
				{
					TargetIdToIndexMap = new Dictionary<int, int>(),
					Targets = new List<EntityHandle>(),
					SignedScreenDistSquaredList = new List<double>(),
					DistSquaredList = new List<double>()
				};
			}
			Dictionary<int, int> targetIdToIndexMap = this.OnScreenTargetInfo.TargetIdToIndexMap;
			List<EntityHandle> targets = this.OnScreenTargetInfo.Targets;
			List<double> signedScreenDistSquaredList = this.OnScreenTargetInfo.SignedScreenDistSquaredList;
			List<double> distSquaredList = this.OnScreenTargetInfo.DistSquaredList;
			targetIdToIndexMap.Clear();
			targets.Clear();
			signedScreenDistSquaredList.Clear();
			distSquaredList.Clear();
			FVectorDouble fvectorDouble = Global.CharacterCameraManager.D_GetCameraLocation();
			bool result = false;
			foreach (EntityHandle entityHandle in new HashSet<EntityHandle>(this.TargetSet))
			{
				if (!this.CheckEntityValid(entityHandle))
				{
					this.TargetSet.Remove(entityHandle);
					result = true;
				}
			}
			this.StartLocation.FromUeVector(fvectorDouble);
			ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(this.StartLocation, (float)this.SelectRange, this.EntityTypeQuery, this.EntitiesInRange, true);
			bool lockIgnoreCheckOnScreen = this.LockIgnoreCheckOnScreen;
			foreach (EntityHandle entityHandle2 in this.EntitiesInRange)
			{
				if (this.CheckEntityValid(entityHandle2))
				{
					FVectorDouble entityLocation = this.GetEntityLocation(entityHandle2);
					bool flag = base.ProjectWorldToScreen(entityLocation, this.ScreenPos, 0.1f);
					double num = this.ScreenPos.SizeSquared();
					bool flag2 = this.CheckEntityRendered(entityHandle2);
					if ((lockIgnoreCheckOnScreen || (flag2 && num < (double)this.ScreenRadiusSquared && flag)) && !this.TargetSet.Contains(entityHandle2))
					{
						this.TargetSet.Add(entityHandle2);
						result = true;
					}
					if (flag2 && flag)
					{
						bool flag3 = this.ScreenPos.X <= 0.0;
						this.TempVector.FromUeVector(entityLocation);
						this.TempVector.SubtractionEqual(this.StartLocation);
						double item = this.TempVector.SizeSquared();
						int count = targets.Count;
						targetIdToIndexMap[entityHandle2.Id] = count;
						targets.Add(entityHandle2);
						signedScreenDistSquaredList.Add(flag3 ? (-num) : num);
						distSquaredList.Add(item);
					}
				}
			}
			this.LockTargetInfo.HackType = ((this.TargetSet.Count > 0) ? new EQuickHackTargetType?(this.TargetHackType) : null);
			return result;
		}

		// Token: 0x0603636B RID: 222059 RVA: 0x00DA9D50 File Offset: 0x00DA7F50
		public override IQuickHackLockTargetInfo GetLockTargetInfo()
		{
			if (this.LockTargetInfo == null)
			{
				this.LockTargetInfo = new QuickHackLockTargetInfo
				{
					HackType = null,
					Targets = this.TargetSet
				};
			}
			return this.LockTargetInfo;
		}

		// Token: 0x0603636C RID: 222060 RVA: 0x00DA9D94 File Offset: 0x00DA7F94
		public override IQuickHackOnScreenTargetInfo GetOnScreenTargetInfo()
		{
			if (this.OnScreenTargetInfo == null)
			{
				this.OnScreenTargetInfo = new QuickHackOnScreenTargetInfo
				{
					TargetIdToIndexMap = new Dictionary<int, int>(),
					Targets = new List<EntityHandle>(),
					SignedScreenDistSquaredList = new List<double>(),
					DistSquaredList = new List<double>()
				};
			}
			return this.OnScreenTargetInfo;
		}

		// Token: 0x0603636D RID: 222061 RVA: 0x00DA9DE6 File Offset: 0x00DA7FE6
		public override void OnExecuteExtraEffect(EQuickHackSkillExtraEffect type)
		{
			if (type == EQuickHackSkillExtraEffect.SelectTargetIgnoreCheckOnScreen)
			{
				this.LockIgnoreCheckOnScreen = true;
			}
		}

		// Token: 0x0603636E RID: 222062
		protected abstract void OnInit();

		// Token: 0x0603636F RID: 222063
		protected abstract bool CheckEntityValid(EntityHandle entityHandle);

		// Token: 0x06036370 RID: 222064
		protected abstract bool CheckEntityRendered(EntityHandle entityHandle);

		// Token: 0x06036371 RID: 222065
		protected abstract FVectorDouble GetEntityLocation(EntityHandle entityHandle);

		// Token: 0x0401F2CD RID: 127693
		protected EEntityTypeQuery EntityTypeQuery = EEntityTypeQuery.PasserbyNPC | EEntityTypeQuery.Boss;

		// Token: 0x0401F2CE RID: 127694
		protected EQuickHackTargetType TargetHackType;

		// Token: 0x0401F2CF RID: 127695
		private readonly List<EntityHandle> EntitiesInRange = new List<EntityHandle>();

		// Token: 0x0401F2D0 RID: 127696
		private readonly HashSet<EntityHandle> TargetSet = new HashSet<EntityHandle>();

		// Token: 0x0401F2D1 RID: 127697
		[Nullable(2)]
		private IQuickHackOnScreenTargetInfo OnScreenTargetInfo;

		// Token: 0x0401F2D2 RID: 127698
		[Nullable(2)]
		private IQuickHackLockTargetInfo LockTargetInfo;

		// Token: 0x0401F2D3 RID: 127699
		private bool LockIgnoreCheckOnScreen;

		// Token: 0x0401F2D4 RID: 127700
		private readonly Vector StartLocation = Vector.Create();

		// Token: 0x0401F2D5 RID: 127701
		private readonly Vector2D ScreenPos = Vector2D.Create();

		// Token: 0x0401F2D6 RID: 127702
		private readonly Vector TempVector = Vector.Create();
	}
}
