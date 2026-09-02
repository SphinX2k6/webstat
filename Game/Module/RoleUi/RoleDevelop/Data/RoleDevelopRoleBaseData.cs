using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.Data
{
	// Token: 0x020050D9 RID: 20697
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class RoleDevelopRoleBaseData
	{
		// Token: 0x0603558A RID: 218506 RVA: 0x00D626B0 File Offset: 0x00D608B0
		public RoleDevelopRoleBaseData(int id)
		{
			this.Id = id;
		}

		// Token: 0x0603558B RID: 218507 RVA: 0x00D626BF File Offset: 0x00D608BF
		public int GetId()
		{
			return this.Id;
		}

		// Token: 0x0603558C RID: 218508
		public abstract ERoleDevelopRoleType GetRoleType();

		// Token: 0x0603558D RID: 218509
		public abstract string GetName();

		// Token: 0x0603558E RID: 218510
		public abstract int GetElementId();

		// Token: 0x0603558F RID: 218511
		public abstract string GetRoleIllustrationPath();

		// Token: 0x06035590 RID: 218512
		public abstract string GetRoleIconPath();

		// Token: 0x06035591 RID: 218513
		public abstract string GetRoleCircleIconPath();

		// Token: 0x06035592 RID: 218514
		public abstract string GetRoleSmallIconPath();

		// Token: 0x06035593 RID: 218515
		public abstract int GetKeyProperty();

		// Token: 0x06035594 RID: 218516
		public abstract int GetRoleLevel();

		// Token: 0x06035595 RID: 218517
		public abstract int GetRoleBreachLevel();

		// Token: 0x06035596 RID: 218518
		public abstract int GetRoleExp();

		// Token: 0x06035597 RID: 218519
		public abstract bool IsRoleMaxLevel();

		// Token: 0x06035598 RID: 218520
		public abstract bool IsRoleNeedBreakUp();

		// Token: 0x06035599 RID: 218521
		public abstract int GetRoleTargetLevel();

		// Token: 0x0603559A RID: 218522
		public abstract int GetRoleTargetBreachLevel();

		// Token: 0x0603559B RID: 218523
		public abstract int GetWeaponType();

		// Token: 0x0603559C RID: 218524
		public abstract WeaponInstance GetWeaponInstance();

		// Token: 0x0603559D RID: 218525
		public abstract string GetWeaponName();

		// Token: 0x0603559E RID: 218526
		public abstract int GetWeaponLevel();

		// Token: 0x0603559F RID: 218527
		public abstract int GetWeaponBreachLevel();

		// Token: 0x060355A0 RID: 218528
		public abstract int GetWeaponExp();

		// Token: 0x060355A1 RID: 218529
		public abstract int GetWeaponTargetLevel();

		// Token: 0x060355A2 RID: 218530
		public abstract int GetWeaponTargetBreachLevel();

		// Token: 0x060355A3 RID: 218531
		public abstract bool IsWeaponMaxLevel();

		// Token: 0x060355A4 RID: 218532
		public abstract bool IsWeaponNeedBreakUp();

		// Token: 0x060355A5 RID: 218533
		public abstract bool CanDevelopPhantom();

		// Token: 0x060355A6 RID: 218534
		public abstract List<int> GetPhantomIdList();

		// Token: 0x060355A7 RID: 218535
		public abstract List<RoleDevelopPhantomSuitData> GetRecommendPhantomSuits(int? planId = null, int? firstVisionMonsterId = null);

		// Token: 0x060355A8 RID: 218536
		public abstract int GetRecommendPlanId();

		// Token: 0x060355A9 RID: 218537
		public abstract int GetRecommendFirstVisionMonsterId();

		// Token: 0x0401EAA4 RID: 125604
		protected readonly int Id;
	}
}
