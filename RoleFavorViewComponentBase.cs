using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200287D RID: 10365
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorViewComponentBase : UiPanelBase
{
	// Token: 0x06014842 RID: 84034 RVA: 0x005B16C9 File Offset: 0x005AF8C9
	public void SetData(RoleFavorContentDataBase contentData, bool isActive = true)
	{
		this.ContentData = contentData;
		this.IsActive = isActive;
		this.OnSetData(contentData);
		if (isActive)
		{
			this.OnRefreshView();
		}
		this.SetComponentActive(isActive);
	}

	// Token: 0x06014843 RID: 84035 RVA: 0x005B16F0 File Offset: 0x005AF8F0
	protected virtual void OnSetData(RoleFavorContentDataBase contentData)
	{
	}

	// Token: 0x06014844 RID: 84036 RVA: 0x005B16F2 File Offset: 0x005AF8F2
	protected virtual void OnRefreshView()
	{
	}

	// Token: 0x06014845 RID: 84037 RVA: 0x005B16F4 File Offset: 0x005AF8F4
	public void SetComponentActive(bool active)
	{
		this.IsActive = active;
		if (this.RootItem != null)
		{
			this.RootItem.SetUIActive(active);
		}
	}

	// Token: 0x06014846 RID: 84038 RVA: 0x005B1711 File Offset: 0x005AF911
	[NullableContext(2)]
	public RoleFavorContentDataBase GetContentData()
	{
		return this.ContentData;
	}

	// Token: 0x06014847 RID: 84039 RVA: 0x005B1719 File Offset: 0x005AF919
	protected override void OnBeforeDestroy()
	{
		this.ContentData = null;
		this.IsActive = false;
	}

	// Token: 0x04009EB2 RID: 40626
	[Nullable(2)]
	protected RoleFavorContentDataBase ContentData;

	// Token: 0x04009EB3 RID: 40627
	protected bool IsActive;
}
