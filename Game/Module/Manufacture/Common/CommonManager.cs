using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Cook;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Module.Manufacture.Forging;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059E2 RID: 23010
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CommonManager : Singleton<CommonManager>
	{
		// Token: 0x0603A4A9 RID: 238761 RVA: 0x00EC7C1C File Offset: 0x00EC5E1C
		public void SetCurrentSystem(ESystemType currentSystem)
		{
			this.CurrentSystem = currentSystem;
		}

		// Token: 0x0603A4AA RID: 238762 RVA: 0x00EC7C25 File Offset: 0x00EC5E25
		public ESystemType GetCurrentSystem()
		{
			return this.CurrentSystem;
		}

		// Token: 0x0603A4AB RID: 238763 RVA: 0x00EC7C30 File Offset: 0x00EC5E30
		public bool CheckIsBuff(int roleId, int itemId)
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem != ESystemType.ComposeSystem)
			{
				return currentSystem == ESystemType.ForgingSystem && ControllerBase<ForgingController>.Instance.CheckIsBuff(roleId, itemId);
			}
			return ControllerBase<ComposeController>.Instance.CheckIsBuff(roleId, itemId);
		}

		// Token: 0x0603A4AC RID: 238764 RVA: 0x00EC7C6C File Offset: 0x00EC5E6C
		public string GetInfoText(int roleId)
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return ControllerBase<ComposeController>.Instance.GetComposeInfoText(roleId);
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return string.Empty;
			}
			return ControllerBase<ForgingController>.Instance.GetForgingInfoText(roleId);
		}

		// Token: 0x0603A4AD RID: 238765 RVA: 0x00EC7CA8 File Offset: 0x00EC5EA8
		public string GetDefaultRoleText()
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return "DefaultComposeHelperText";
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return "DefaultHelperText";
			}
			return "DefaultForgingHelperText";
		}

		// Token: 0x0603A4AE RID: 238766 RVA: 0x00EC7CD8 File Offset: 0x00EC5ED8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ICommonPopItemData> GetCommonItemList()
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return ControllerBase<ComposeController>.Instance.GetComposeItemList();
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return null;
			}
			return ControllerBase<ForgingController>.Instance.GetForgingItemList();
		}

		// Token: 0x0603A4AF RID: 238767 RVA: 0x00EC7D0D File Offset: 0x00EC5F0D
		public int GetCurrentFixId()
		{
			return ControllerBase<CookController>.Instance.GetCurrentFixId();
		}

		// Token: 0x0603A4B0 RID: 238768 RVA: 0x00EC7D19 File Offset: 0x00EC5F19
		public bool CheckCanFix()
		{
			return ControllerBase<CookController>.Instance.CheckCanFix();
		}

		// Token: 0x0603A4B1 RID: 238769 RVA: 0x00EC7D28 File Offset: 0x00EC5F28
		public void SendFixToolRequest()
		{
			ControllerBase<CookController>.Instance.SendFixToolRequest(ControllerBase<CookController>.Instance.GetCurrentFixId(), ControllerBase<CookController>.Instance.GetCurrentEntityId().Value);
		}

		// Token: 0x0603A4B2 RID: 238770 RVA: 0x00EC7D5C File Offset: 0x00EC5F5C
		public int? GetSelectedLevel()
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				return new int?(ControllerBase<ComposeController>.Instance.GetSelectedComposeLevel());
			}
			return null;
		}

		// Token: 0x0603A4B3 RID: 238771 RVA: 0x00EC7D8B File Offset: 0x00EC5F8B
		public void SetSelectedLevel(int level)
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				ControllerBase<ComposeController>.Instance.SetSelectedComposeLevel(level);
			}
		}

		// Token: 0x0603A4B4 RID: 238772 RVA: 0x00EC7DA4 File Offset: 0x00EC5FA4
		public int? GetCurrentRewardLevel()
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				return new int?(ControllerBase<ComposeController>.Instance.GetRewardLevelInfo().ComposeLevel);
			}
			return null;
		}

		// Token: 0x0603A4B5 RID: 238773 RVA: 0x00EC7DD8 File Offset: 0x00EC5FD8
		public int? GetCurrentRewardTotalProficiency()
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				return new int?(ControllerBase<ComposeController>.Instance.GetRewardLevelInfo().TotalProficiency);
			}
			return null;
		}

		// Token: 0x0603A4B6 RID: 238774 RVA: 0x00EC7E0C File Offset: 0x00EC600C
		public int? GetCurrentRewardAddExp()
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				return new int?(ControllerBase<ComposeController>.Instance.GetRewardLevelInfo().AddExp);
			}
			return null;
		}

		// Token: 0x0603A4B7 RID: 238775 RVA: 0x00EC7E40 File Offset: 0x00EC6040
		public SynthesisLevel? GetComposeLevelByLevel(int level)
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				return ControllerBase<ComposeController>.Instance.GetComposeLevelByLevel(level);
			}
			return null;
		}

		// Token: 0x0603A4B8 RID: 238776 RVA: 0x00EC7E6C File Offset: 0x00EC606C
		[NullableContext(2)]
		public string GetLevelUpgradeTypeTexture(int level)
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
				defaultInterpolatedStringHandler.AppendLiteral("T_ComposeTypeLevel");
				defaultInterpolatedStringHandler.AppendFormatted<int>(level);
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return null;
		}

		// Token: 0x0603A4B9 RID: 238777 RVA: 0x00EC7EAC File Offset: 0x00EC60AC
		public int? GetSumExpByLevel(int level)
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				return new int?(ControllerBase<ComposeController>.Instance.GetSumExpByLevel(level));
			}
			return null;
		}

		// Token: 0x0603A4BA RID: 238778 RVA: 0x00EC7EDC File Offset: 0x00EC60DC
		public int? GetDropIdByLevel(int level)
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				return new int?(ControllerBase<ComposeController>.Instance.GetDropIdByLevel(level));
			}
			return null;
		}

		// Token: 0x0603A4BB RID: 238779 RVA: 0x00EC7F0C File Offset: 0x00EC610C
		public int? GetComposeMaxLevel()
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				return new int?(ControllerBase<ComposeController>.Instance.GetComposeMaxLevel());
			}
			return null;
		}

		// Token: 0x0603A4BC RID: 238780 RVA: 0x00EC7F3B File Offset: 0x00EC613B
		public void SendLevelRewardRequest()
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				ControllerBase<ComposeController>.Instance.SendSynthesisLevelRewardRequest();
			}
		}

		// Token: 0x0603A4BD RID: 238781 RVA: 0x00EC7F50 File Offset: 0x00EC6150
		public bool CheckIsBuffEx(int roleId, int itemId)
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem != ESystemType.ComposeSystem)
			{
				return currentSystem == ESystemType.ForgingSystem && ControllerBase<ForgingController>.Instance.CheckIsBuffEx(roleId, itemId);
			}
			return ControllerBase<ComposeController>.Instance.CheckIsBuffEx(roleId, itemId);
		}

		// Token: 0x0603A4BE RID: 238782 RVA: 0x00EC7F8C File Offset: 0x00EC618C
		[NullableContext(2)]
		public string GetCommonManufactureText(int itemId)
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return ControllerBase<ComposeController>.Instance.GetComposeText(itemId);
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return null;
			}
			return ControllerBase<ForgingController>.Instance.GetForgingText(itemId);
		}

		// Token: 0x0603A4BF RID: 238783 RVA: 0x00EC7FC4 File Offset: 0x00EC61C4
		public int? GetCommonManufactureId(int id)
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return new int?(ControllerBase<ComposeController>.Instance.GetComposeId(id));
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return null;
			}
			return new int?(ControllerBase<ForgingController>.Instance.GetForgingId(id));
		}

		// Token: 0x0603A4C0 RID: 238784 RVA: 0x00EC8010 File Offset: 0x00EC6210
		public bool? CheckShowRoleView()
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return new bool?(ControllerBase<ComposeController>.Instance.CheckShowRoleView());
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return null;
			}
			return new bool?(ControllerBase<ForgingController>.Instance.CheckShowRoleView());
		}

		// Token: 0x0603A4C1 RID: 238785 RVA: 0x00EC8057 File Offset: 0x00EC6257
		public int GetMaxCreateCount(int itemId)
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				return ControllerBase<ComposeController>.Instance.GetMaxCreateCount(itemId, null);
			}
			return ControllerBase<ForgingController>.Instance.GetMaxCreateCount(itemId);
		}

		// Token: 0x0603A4C2 RID: 238786 RVA: 0x00EC807C File Offset: 0x00EC627C
		public bool? CheckCanManufacture(int itemId)
		{
			if (this.CurrentSystem == ESystemType.ForgingSystem)
			{
				return new bool?(ControllerBase<ForgingController>.Instance.CheckCanForging(itemId));
			}
			return null;
		}

		// Token: 0x0603A4C3 RID: 238787 RVA: 0x00EC80AC File Offset: 0x00EC62AC
		public void SendManufacture(int itemId, int count)
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				ControllerBase<ComposeController>.Instance.SendManufacture(itemId, count).Forget();
				return;
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return;
			}
			ControllerBase<ForgingController>.Instance.SendManufacture(itemId, count);
		}

		// Token: 0x0603A4C4 RID: 238788 RVA: 0x00EC80E8 File Offset: 0x00EC62E8
		public int? GetCurrentRoleId()
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return new int?(ControllerBase<ComposeController>.Instance.GetCurrentRoleId());
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return null;
			}
			return new int?(ControllerBase<ForgingController>.Instance.GetCurrentRoleId());
		}

		// Token: 0x0603A4C5 RID: 238789 RVA: 0x00EC8130 File Offset: 0x00EC6330
		public void SetCurrentRoleId(int roleId)
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				ControllerBase<ComposeController>.Instance.SetCurrentRoleId(roleId);
				return;
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return;
			}
			ControllerBase<ForgingController>.Instance.SetCurrentRoleId(roleId);
		}

		// Token: 0x0603A4C6 RID: 238790 RVA: 0x00EC8164 File Offset: 0x00EC6364
		public int? GetManufactureRoleId(int itemId)
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return new int?(ControllerBase<ComposeController>.Instance.GetComposeRoleId(itemId));
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return null;
			}
			return new int?(ControllerBase<ForgingController>.Instance.GetForgingRoleId(itemId));
		}

		// Token: 0x0603A4C7 RID: 238791 RVA: 0x00EC81B0 File Offset: 0x00EC63B0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ISingleItemInfo> GetManufactureMaterialList(int itemId)
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return ControllerBase<ComposeController>.Instance.GetManufactureMaterialList(itemId);
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return null;
			}
			return ControllerBase<ForgingController>.Instance.GetForgingMaterialList(itemId);
		}

		// Token: 0x0603A4C8 RID: 238792 RVA: 0x00EC81E8 File Offset: 0x00EC63E8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ICommonRoleItemData> GetHelpRoleItemDataList(int itemId)
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return ControllerBase<ComposeController>.Instance.GetHelpRoleItemDataList(itemId);
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return null;
			}
			return ControllerBase<ForgingController>.Instance.GetHelpRoleItemDataList(itemId);
		}

		// Token: 0x0603A4C9 RID: 238793 RVA: 0x00EC8220 File Offset: 0x00EC6420
		public bool? CheckCanShowExpItem()
		{
			if (this.CurrentSystem == ESystemType.ComposeSystem)
			{
				return new bool?(ControllerBase<ComposeController>.Instance.CheckCanShowExpItem());
			}
			return null;
		}

		// Token: 0x0603A4CA RID: 238794 RVA: 0x00EC8250 File Offset: 0x00EC6450
		public bool? CheckShowAmountItem()
		{
			ESystemType currentSystem = this.CurrentSystem;
			if (currentSystem == ESystemType.ComposeSystem)
			{
				return new bool?(true);
			}
			if (currentSystem != ESystemType.ForgingSystem)
			{
				return null;
			}
			return new bool?(false);
		}

		// Token: 0x0402107E RID: 135294
		private ESystemType CurrentSystem;
	}
}
