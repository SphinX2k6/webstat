using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.Views
{
	// Token: 0x02005776 RID: 22390
	[NullableContext(1)]
	[Nullable(0)]
	public class MenuVersionCheckData : MenuData
	{
		// Token: 0x06038FCF RID: 233423 RVA: 0x00E7096B File Offset: 0x00E6EB6B
		public MenuVersionCheckData(MenuConfig Config) : base(Config)
		{
		}

		// Token: 0x17009197 RID: 37271
		// (get) Token: 0x06038FD0 RID: 233424 RVA: 0x00E70974 File Offset: 0x00E6EB74
		public override string FunctionName
		{
			get
			{
				return "CurrentVersion";
			}
		}

		// Token: 0x17009198 RID: 37272
		// (get) Token: 0x06038FD1 RID: 233425 RVA: 0x00E7097B File Offset: 0x00E6EB7B
		public override string ButtonTextId
		{
			get
			{
				if (!ControllerBase<ParallelPackageController>.Instance.CheckParallelPackage())
				{
					return "NewVersionTip01";
				}
				return "NewVersionTip02";
			}
		}

		// Token: 0x17009199 RID: 37273
		// (get) Token: 0x06038FD2 RID: 233426 RVA: 0x00E70994 File Offset: 0x00E6EB94
		public override string[] CustomTitleArgs
		{
			get
			{
				return new string[]
				{
					UKuroLauncherLibrary.GetAppVersion()
				};
			}
		}

		// Token: 0x1700919A RID: 37274
		// (get) Token: 0x06038FD3 RID: 233427 RVA: 0x00E709A4 File Offset: 0x00E6EBA4
		public override bool EnableRedDot
		{
			get
			{
				return ControllerBase<ParallelPackageController>.Instance.CheckParallelPackage();
			}
		}

		// Token: 0x06038FD4 RID: 233428 RVA: 0x00E709B0 File Offset: 0x00E6EBB0
		public override void OnRefresh()
		{
			this.RefreshVersionCheckRedDotIsRead();
		}

		// Token: 0x06038FD5 RID: 233429 RVA: 0x00E709B8 File Offset: 0x00E6EBB8
		private void RefreshVersionCheckRedDotIsRead()
		{
			RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(ERedDotName.RedDotVersionCheck);
			if (redDot != null && redDot.IsRedDotActive())
			{
				LocalStorage.SetPlayer<string>(ELocalStoragePlayerKey.VersionRedDotMap, UKuroLauncherLibrary.GetAppVersion());
				Singleton<EventSystem>.Instance.Emit(EEventName.VersionCheckRefresh);
			}
		}

		// Token: 0x06038FD6 RID: 233430 RVA: 0x00E709F4 File Offset: 0x00E6EBF4
		public override bool GetButtonEnable()
		{
			return ControllerBase<ParallelPackageController>.Instance.CheckParallelPackage();
		}
	}
}
