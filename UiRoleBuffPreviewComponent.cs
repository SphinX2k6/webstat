using System;
using System.Collections.Generic;
using CSharpScript.Game.Common.Event;

// Token: 0x02002CA7 RID: 11431
public class UiRoleBuffPreviewComponent : UiModelBuffComponent
{
	// Token: 0x06016F01 RID: 93953 RVA: 0x0065BAE8 File Offset: 0x00659CE8
	protected override void OnStart()
	{
		base.OnStart();
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnBeforeUiModelLoadStart));
	}

	// Token: 0x06016F02 RID: 93954 RVA: 0x0065BB40 File Offset: 0x00659D40
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnBeforeUiModelLoadStart));
		base.OnEnd();
	}

	// Token: 0x06016F03 RID: 93955 RVA: 0x0065BB97 File Offset: 0x00659D97
	private void OnBeforeUiModelLoadStart()
	{
		base.RemoveAllBuffId();
	}

	// Token: 0x06016F04 RID: 93956 RVA: 0x0065BBA0 File Offset: 0x00659DA0
	private void OnRoleMeshLoadComplete()
	{
		List<long> currentPreviewItemBuffList = ModelBase<BuffItemModel>.Instance.GetCurrentPreviewItemBuffList();
		if (currentPreviewItemBuffList == null || currentPreviewItemBuffList.Count == 0)
		{
			return;
		}
		foreach (long buffId in currentPreviewItemBuffList)
		{
			base.AddBuffByBuffId(buffId);
		}
	}
}
