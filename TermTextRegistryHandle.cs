using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002BA5 RID: 11173
[NullableContext(2)]
[Nullable(0)]
public class TermTextRegistryHandle
{
	// Token: 0x17001D47 RID: 7495
	// (get) Token: 0x06016415 RID: 91157 RVA: 0x0062AEE6 File Offset: 0x006290E6
	public UUIText UiText
	{
		get
		{
			return this.UiTextInternal;
		}
	}

	// Token: 0x17001D48 RID: 7496
	// (get) Token: 0x06016416 RID: 91158 RVA: 0x0062AEEE File Offset: 0x006290EE
	public bool Enable
	{
		get
		{
			return this.EnableInternal;
		}
	}

	// Token: 0x17001D49 RID: 7497
	// (get) Token: 0x06016417 RID: 91159 RVA: 0x0062AEF6 File Offset: 0x006290F6
	public ETermExplanationViewType Type
	{
		get
		{
			return this.TypeInternal;
		}
	}

	// Token: 0x06016418 RID: 91160 RVA: 0x0062AEFE File Offset: 0x006290FE
	public void SetEnable(bool enable)
	{
		this.EnableInternal = enable;
		this.IsEnableStateDirty = true;
	}

	// Token: 0x06016419 RID: 91161 RVA: 0x0062AF0E File Offset: 0x0062910E
	public void SetUiText(UUIText uiText)
	{
		this.UiTextInternal = uiText;
	}

	// Token: 0x0601641A RID: 91162 RVA: 0x0062AF17 File Offset: 0x00629117
	public void SetType(ETermExplanationViewType type)
	{
		this.TypeInternal = type;
	}

	// Token: 0x0601641B RID: 91163 RVA: 0x0062AF20 File Offset: 0x00629120
	public void Clear()
	{
		UUIText uiText = this.UiText;
		AUIBaseActor auibaseActor = ((uiText != null) ? uiText.GetOwner() : null) as AUIBaseActor;
		if (auibaseActor != null)
		{
			FUIBaseActorPreDestroyedSignature onPreDestroyed = auibaseActor.OnPreDestroyed;
			if (onPreDestroyed != null)
			{
				onPreDestroyed.Clear();
			}
		}
		UUIText uiText2 = this.UiText;
		if (uiText2 != null && uiText2.IsValid())
		{
			this.UiText.OnHyperLinkClickCallBack.Unbind();
		}
		this.SetEnable(true);
		this.SetUiText(null);
		this.SetType(ETermExplanationViewType.Center);
		this.OnDisableClick = null;
		this.ViewId = 0;
		this.AttachDir = ETermExplanationViewAttachDirection.None;
		this.AttachItem = null;
		this.Offset = new ValueTuple<float, float>(0f, 0f);
		this.NeedHighlight = true;
		this.Group = ETermExplanationGroup.Default;
		this.Priority = 0;
		this.IsEnableStateDirty = false;
		this.Style = ETermExplanationViewStyle.Default;
		this.ReportType = null;
		this.Id = 0;
	}

	// Token: 0x0400AC1B RID: 44059
	public int Id;

	// Token: 0x0400AC1C RID: 44060
	private UUIText UiTextInternal;

	// Token: 0x0400AC1D RID: 44061
	private bool EnableInternal = true;

	// Token: 0x0400AC1E RID: 44062
	private ETermExplanationViewType TypeInternal;

	// Token: 0x0400AC1F RID: 44063
	public int ViewId;

	// Token: 0x0400AC20 RID: 44064
	public ETermExplanationViewAttachDirection AttachDir;

	// Token: 0x0400AC21 RID: 44065
	public UUIItem AttachItem;

	// Token: 0x0400AC22 RID: 44066
	public Action OnDisableClick;

	// Token: 0x0400AC23 RID: 44067
	[Nullable(0)]
	public ValueTuple<float, float> Offset = new ValueTuple<float, float>(0f, 0f);

	// Token: 0x0400AC24 RID: 44068
	public bool NeedHighlight = true;

	// Token: 0x0400AC25 RID: 44069
	[Nullable(1)]
	public string LastText = "";

	// Token: 0x0400AC26 RID: 44070
	public bool LastHierarchyActive;

	// Token: 0x0400AC27 RID: 44071
	public ETermExplanationGroup Group;

	// Token: 0x0400AC28 RID: 44072
	public int Priority;

	// Token: 0x0400AC29 RID: 44073
	public bool IsEnableStateDirty;

	// Token: 0x0400AC2A RID: 44074
	public ETermExplanationViewStyle Style = ETermExplanationViewStyle.Default;

	// Token: 0x0400AC2B RID: 44075
	public ETermExplanationReportType? ReportType;
}
