using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020026C6 RID: 9926
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestTreeNodeTargetItem : GridProxyAbstract<IQuestTreeNodeTarget>
{
	// Token: 0x06013950 RID: 80208 RVA: 0x00576798 File Offset: 0x00574998
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnSelfClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013951 RID: 80209 RVA: 0x005768E3 File Offset: 0x00574AE3
	public void SetNode(QuestTreeNodeData node)
	{
		this.Node = node;
	}

	// Token: 0x06013952 RID: 80210 RVA: 0x005768EC File Offset: 0x00574AEC
	public override void Refresh(IQuestTreeNodeTarget data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		base.GetItem(1).SetUIActive(data.Type == EQuestTreeNodeTargetType.Step);
		base.GetItem(3).SetUIActive(data.IsFinished.GetValueOrDefault());
		UUIItem item = base.GetItem(4);
		bool flag;
		if (data != null)
		{
			int? helpId = data.HelpId;
			if (helpId != null && helpId.GetValueOrDefault() != 0 && !(data.IsFinished ?? false))
			{
				flag = true;
				goto IL_78;
			}
		}
		flag = false;
		IL_78:
		item.SetUIActive(flag);
		UUIItem item2 = base.GetItem(5);
		flag = ((data.GotoId ?? 0) != 0 || data.OnGoto != null);
		if (flag)
		{
			bool flag2 = !(data.IsFinished ?? false);
			flag = flag2;
		}
		item2.SetUIActive(flag);
		UUIItem item3 = base.GetItem(6);
		bool uiactive;
		if (!data.IsFinished.GetValueOrDefault() && data.Type == EQuestTreeNodeTargetType.UnlockCondition)
		{
			if (data.HelpId != null)
			{
				int? helpId = data.HelpId;
				int num = 0;
				if (!(helpId.GetValueOrDefault() == num & helpId != null))
				{
					goto IL_132;
				}
			}
			uiactive = (data.OnGoto == null);
			goto IL_133;
		}
		IL_132:
		uiactive = false;
		IL_133:
		item3.SetUIActive(uiactive);
		if (!string.IsNullOrEmpty(data.Text))
		{
			base.GetText(2).SetText(data.Text, true);
		}
		else if (!string.IsNullOrEmpty(data.TextKey))
		{
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(2);
			string textKey = data.TextKey;
			List<object> textParam = data.TextParam;
			instance.SetLocalTextNew(text, textKey, ((textParam != null) ? textParam.ToArray() : null) ?? Array.Empty<object>());
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (data.IsFinished.GetValueOrDefault() || data.Type == EQuestTreeNodeTargetType.Step)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnDetermined, false, true, true);
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06013953 RID: 80211 RVA: 0x00576ACC File Offset: 0x00574CCC
	private void OnSelfClick(EToggleState _)
	{
		if (this.Data.OnGoto != null && !this.Data.IsFinished.GetValueOrDefault())
		{
			this.Data.OnGoto();
		}
		if (this.Data.HelpId != null)
		{
			int? helpId = this.Data.HelpId;
			int num = 0;
			if (helpId.GetValueOrDefault() > num & helpId != null)
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(this.Data.HelpId.Value);
			}
		}
		if (this.Node != null)
		{
			ControllerBase<QuestTreeController>.Instance.ReportJump(this.Node, EQuestTreeLogReportJumpMotion.PreQuest);
		}
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04009874 RID: 39028
	private IQuestTreeNodeTarget Data;

	// Token: 0x04009875 RID: 39029
	[Nullable(2)]
	private QuestTreeNodeData Node;

	// Token: 0x02008A76 RID: 35446
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EB38 RID: 191288
		public const int ToggleSelf = 0;

		// Token: 0x0402EB39 RID: 191289
		public const int ItemLeftIcon = 1;

		// Token: 0x0402EB3A RID: 191290
		public const int TextDesc = 2;

		// Token: 0x0402EB3B RID: 191291
		public const int ItemFinished = 3;

		// Token: 0x0402EB3C RID: 191292
		public const int ItemHelp = 4;

		// Token: 0x0402EB3D RID: 191293
		public const int ItemGoto = 5;

		// Token: 0x0402EB3E RID: 191294
		public const int ItemLock = 6;
	}
}
