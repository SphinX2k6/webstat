using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050C4 RID: 20676
	public class RoleDevelopProjectWeaponPanel : RoleDevelopProjectBasePanel
	{
		// Token: 0x06035459 RID: 218201 RVA: 0x00D5C90C File Offset: 0x00D5AB0C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603545A RID: 218202 RVA: 0x00D5C978 File Offset: 0x00D5AB78
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopProjectWeaponPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopProjectWeaponPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603545B RID: 218203 RVA: 0x00D5C9BB File Offset: 0x00D5ABBB
		public override void OnCommonItemCountAnyChange(int configId)
		{
			this.WeaponDevItem.OnCommonItemCountAnyChange(configId);
		}

		// Token: 0x0603545C RID: 218204 RVA: 0x00D5C9C9 File Offset: 0x00D5ABC9
		protected override void OnRefreshView(bool forceRefresh)
		{
			this.InitSelectWeaponType(forceRefresh);
			this.RefreshWeaponView();
		}

		// Token: 0x0603545D RID: 218205 RVA: 0x00D5C9D8 File Offset: 0x00D5ABD8
		private void InitSelectWeaponType(bool reset = false)
		{
			if (this.CurSelectWeaponType != null && !reset)
			{
				return;
			}
			WeaponInstance weaponInstance = this.Data.GetDevelopRoleData().GetWeaponInstance();
			if (weaponInstance != null && !ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponInstance))
			{
				this.CurSelectWeaponType = new ERoleDevelopWeaponType?(ERoleDevelopWeaponType.Recommend);
				return;
			}
			this.CurSelectWeaponType = new ERoleDevelopWeaponType?(ERoleDevelopWeaponType.Develop);
		}

		// Token: 0x0603545E RID: 218206 RVA: 0x00D5CA30 File Offset: 0x00D5AC30
		private void RefreshWeaponView()
		{
			RoleDevelopData data = this.Data;
			this.WeaponDevItem.SetUiActive(this.CurSelectWeaponType.GetValueOrDefault() == ERoleDevelopWeaponType.Develop);
			this.WeaponRecommendItem.SetUiActive(this.CurSelectWeaponType.GetValueOrDefault() == ERoleDevelopWeaponType.Recommend);
			if (this.CurSelectWeaponType.GetValueOrDefault() == ERoleDevelopWeaponType.Develop)
			{
				this.WeaponDevItem.RefreshByData(data);
				return;
			}
			this.WeaponRecommendItem.RefreshByData(data);
		}

		// Token: 0x0603545F RID: 218207 RVA: 0x00D5CA9D File Offset: 0x00D5AC9D
		private void OnClickSwitchButton()
		{
			this.CurSelectWeaponType = new ERoleDevelopWeaponType?((this.CurSelectWeaponType.GetValueOrDefault() == ERoleDevelopWeaponType.Develop) ? ERoleDevelopWeaponType.Recommend : ERoleDevelopWeaponType.Develop);
			this.RefreshWeaponView();
		}

		// Token: 0x0401EA58 RID: 125528
		private ERoleDevelopWeaponType? CurSelectWeaponType;

		// Token: 0x0401EA59 RID: 125529
		[Nullable(1)]
		private RoleDevelopProjectWeaponDevItem WeaponDevItem;

		// Token: 0x0401EA5A RID: 125530
		[Nullable(1)]
		private RoleDevelopProjectWeaponRecommendItem WeaponRecommendItem;

		// Token: 0x0200B05A RID: 45146
		public static class EComponentType
		{
			// Token: 0x04036B75 RID: 224117
			public const int PlanWeaponDevelop = 0;

			// Token: 0x04036B76 RID: 224118
			public const int PlanWeaponRecommend = 1;
		}
	}
}
