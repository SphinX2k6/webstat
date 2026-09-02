using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020019F3 RID: 6643
[NullableContext(2)]
[Nullable(0)]
public class MediumItemGridWarningPanelComponent : MediumItemGridComponent
{
	// Token: 0x0600BE3B RID: 48699 RVA: 0x0032618E File Offset: 0x0032438E
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_RoleComOccupy";
	}

	// Token: 0x0600BE3C RID: 48700 RVA: 0x00326198 File Offset: 0x00324398
	protected override UniTask OnBeforeStartAsync()
	{
		MediumItemGridWarningPanelComponent.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MediumItemGridWarningPanelComponent.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BE3D RID: 48701 RVA: 0x003261DC File Offset: 0x003243DC
	protected override void OnRefresh(object data)
	{
		MediumWarningPanelInfo mediumWarningPanelInfo = data as MediumWarningPanelInfo;
		if (mediumWarningPanelInfo == null)
		{
			return;
		}
		if (!string.IsNullOrEmpty(mediumWarningPanelInfo.IconPath))
		{
			CommonWarningItem warningItem = this.WarningItem;
			if (warningItem != null)
			{
				warningItem.SetWarningIcon(mediumWarningPanelInfo.IconPath);
			}
		}
		CommonWarningItem warningItem2 = this.WarningItem;
		if (warningItem2 != null)
		{
			warningItem2.SetIconVisible(mediumWarningPanelInfo.IconPath != null);
		}
		CommonWarningItem warningItem3 = this.WarningItem;
		if (warningItem3 != null)
		{
			warningItem3.SetShowText(mediumWarningPanelInfo.TipText);
		}
		this.SetActive(true);
	}

	// Token: 0x0400597A RID: 22906
	private CommonWarningItem WarningItem;
}
