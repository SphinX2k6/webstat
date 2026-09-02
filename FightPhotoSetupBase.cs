using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Ui;

// Token: 0x020025CA RID: 9674
public abstract class FightPhotoSetupBase : UiPanelBase
{
	// Token: 0x06012E99 RID: 77465 RVA: 0x0053B90B File Offset: 0x00539B0B
	public void Initialize(int configId)
	{
		this.SetupConfig = ConfigBase<PhotographConfig>.Instance.GetFightPhotoSetupConfigById(configId);
		this.Refresh();
	}

	// Token: 0x06012E9A RID: 77466
	public abstract void Refresh();

	// Token: 0x06012E9B RID: 77467 RVA: 0x0053B924 File Offset: 0x00539B24
	protected void OnSetupValueChange(int value)
	{
		PhotographController.SetFightPhotographSetupOption((EFightPhotoSetupOptionType)this.SetupConfig.Value.Id, value, false);
		if (this.SetupConfig.Value.IsLocalStorage)
		{
			Dictionary<int, int> dictionary = LocalStorage.GetGlobal<Dictionary<int, int>>(ELocalStorageGlobalKey.FightPhotographSetupOption, null) ?? new Dictionary<int, int>();
			dictionary[this.SetupConfig.Value.Id] = value;
			LocalStorage.SetGlobal<Dictionary<int, int>>(ELocalStorageGlobalKey.FightPhotographSetupOption, dictionary);
		}
	}

	// Token: 0x040093BC RID: 37820
	protected FightPhotoSetup? SetupConfig;
}
