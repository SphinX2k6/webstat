using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002C93 RID: 11411
[NullableContext(1)]
[Nullable(0)]
public class UiModelTagComponent : UiModelComponentBase
{
	// Token: 0x06016E6E RID: 93806 RVA: 0x00659DCE File Offset: 0x00657FCE
	protected override void OnInit()
	{
		this.AnsControllerComponent = base.Owner.CheckGetComponent<UiModelAnsControllerComponent>();
	}

	// Token: 0x06016E6F RID: 93807 RVA: 0x00659DE4 File Offset: 0x00657FE4
	protected override void OnStart()
	{
		UiModelAnsControllerComponent ansControllerComponent = this.AnsControllerComponent;
		if (ansControllerComponent != null)
		{
			ansControllerComponent.RegisterAnsTrigger("UiTagAnsContext", new Action<UiAnsContextBase>(this.OnAnsBegin), new Action<UiAnsContextBase>(this.OnAnsEnd));
		}
		this.TagComponent.AddListener(GameplayTagDefine.EGameplayTagId["UI.角色.显示属性切换预览特效"], new TTagSwitchedCallback(this.OnShowElementChangePreviewEffect));
		this.TagComponent.AddListener(GameplayTagDefine.EGameplayTagId["UI.角色.葫芦灯光动画"], new TTagSwitchedCallback(this.OnHuluLightSequenceEvent));
	}

	// Token: 0x06016E70 RID: 93808 RVA: 0x00659E6C File Offset: 0x0065806C
	protected override void OnEnd()
	{
		this.TagComponent.RemoveListener(GameplayTagDefine.EGameplayTagId["UI.角色.显示属性切换预览特效"], new TTagSwitchedCallback(this.OnShowElementChangePreviewEffect));
		this.TagComponent.RemoveListener(GameplayTagDefine.EGameplayTagId["UI.角色.葫芦灯光动画"], new TTagSwitchedCallback(this.OnHuluLightSequenceEvent));
	}

	// Token: 0x06016E71 RID: 93809 RVA: 0x00659EC5 File Offset: 0x006580C5
	protected override void OnClear()
	{
		this.TagComponent.RemoveAllTag();
	}

	// Token: 0x06016E72 RID: 93810 RVA: 0x00659ED2 File Offset: 0x006580D2
	public void AddTagById(int tagId, params object[] args)
	{
		this.TagComponent.AddTagById(tagId, args);
	}

	// Token: 0x06016E73 RID: 93811 RVA: 0x00659EE1 File Offset: 0x006580E1
	public void ReduceTagById(int tagId, params object[] args)
	{
		this.TagComponent.ReduceTagById(tagId, args);
	}

	// Token: 0x06016E74 RID: 93812 RVA: 0x00659EF0 File Offset: 0x006580F0
	public bool ContainsTagById(int tagId)
	{
		return this.TagComponent.ContainsTagById(tagId);
	}

	// Token: 0x06016E75 RID: 93813 RVA: 0x00659EFE File Offset: 0x006580FE
	public void AddTagListener(int tagId, TTagSwitchedCallback callback)
	{
		this.TagComponent.AddListener(tagId, callback);
	}

	// Token: 0x06016E76 RID: 93814 RVA: 0x00659F0D File Offset: 0x0065810D
	public void RemoveTagListener(int tagId, TTagSwitchedCallback callback)
	{
		this.TagComponent.RemoveListener(tagId, callback);
	}

	// Token: 0x06016E77 RID: 93815 RVA: 0x00659F1C File Offset: 0x0065811C
	public void OnAnsBegin(UiAnsContextBase ansContext)
	{
		UiTagAnsContext uiTagAnsContext = ansContext as UiTagAnsContext;
		this.AddTagById(uiTagAnsContext.TagId, Array.Empty<object>());
	}

	// Token: 0x06016E78 RID: 93816 RVA: 0x00659F44 File Offset: 0x00658144
	public void OnAnsEnd(UiAnsContextBase ansContext)
	{
		UiTagAnsContext uiTagAnsContext = ansContext as UiTagAnsContext;
		this.ReduceTagById(uiTagAnsContext.TagId, Array.Empty<object>());
	}

	// Token: 0x06016E79 RID: 93817 RVA: 0x00659F69 File Offset: 0x00658169
	private void OnShowElementChangePreviewEffect(int tagId, bool tagExist, params object[] _)
	{
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.ShowRoleElementChangePreviewEffect, tagExist);
	}

	// Token: 0x06016E7A RID: 93818 RVA: 0x00659F7C File Offset: 0x0065817C
	private void OnHuluLightSequenceEvent(int tagId, bool tagExist, params object[] _)
	{
		UiRoleHuluLightSequenceComponent uiRoleHuluLightSequenceComponent = base.Owner.CheckGetComponent<UiRoleHuluLightSequenceComponent>();
		if (tagExist)
		{
			if (uiRoleHuluLightSequenceComponent != null)
			{
				uiRoleHuluLightSequenceComponent.PlayLightSequence();
				return;
			}
		}
		else if (uiRoleHuluLightSequenceComponent != null)
		{
			uiRoleHuluLightSequenceComponent.StopLightSequence();
		}
	}

	// Token: 0x0400B0A7 RID: 45223
	private readonly UiTagComponent TagComponent = new UiTagComponent();

	// Token: 0x0400B0A8 RID: 45224
	[Nullable(2)]
	private UiModelAnsControllerComponent AnsControllerComponent;
}
