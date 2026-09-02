using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F39 RID: 20281
	public class SkipTaskWeaponRoot : SkipTask
	{
		// Token: 0x060345D4 RID: 214484 RVA: 0x00D1AF80 File Offset: 0x00D19180
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			int num = (int)data[0];
			WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(num);
			if (weaponDataByIncId == null)
			{
				base.Finish();
				return;
			}
			int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(weaponDataByIncId.GetRoleId());
			WeaponRootViewParam param = new WeaponRootViewParam
			{
				WeaponIncId = num,
				WeaponSkinId = skinIdByRoleId,
				IsFromRoleRootView = false
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponRootView, param, null);
			base.Finish();
		}
	}
}
