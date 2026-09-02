using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002482 RID: 9346
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhantomManagerConfigNewFetterItem : GridProxyAbstract<IPhantomManagerFetterInfo>
{
	// Token: 0x06012236 RID: 74294 RVA: 0x004FC674 File Offset: 0x004FA874
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06012237 RID: 74295 RVA: 0x004FC720 File Offset: 0x004FA920
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomManagerConfigNewFetterItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomManagerConfigNewFetterItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012238 RID: 74296 RVA: 0x004FC764 File Offset: 0x004FA964
	[NullableContext(1)]
	public override void Refresh(IPhantomManagerFetterInfo data, bool isSelected, int gridIndex)
	{
		this.CurrentId = data.FetterId;
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data.FetterId);
		PhantomManagerConfigNewElementItem elementItem = this.ElementItem;
		if (elementItem != null)
		{
			elementItem.Refresh(fetterGroupById.FetterElementPath);
		}
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(fetterGroupById.FetterGroupName);
		UUIText text = base.GetText(1);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendFormatted(configTextByKey);
			defaultInterpolatedStringHandler.AppendLiteral(" (");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		if (this.IsSelectOnCb != null)
		{
			this.SetSelected(this.IsSelectOnCb(data.FetterId), false);
		}
		bool fetterConfigIsOpen = ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData().GetFetterConfigIsOpen(data.FetterId);
		UUISprite sprite = base.GetSprite(3);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(fetterConfigIsOpen);
	}

	// Token: 0x06012239 RID: 74297 RVA: 0x004FC850 File Offset: 0x004FAA50
	public override void OnSelected(bool fireEvent)
	{
		if (this.IsSelectOnCb != null && this.CurrentId > 0)
		{
			this.SetSelected(this.IsSelectOnCb(this.CurrentId), false);
		}
	}

	// Token: 0x0601223A RID: 74298 RVA: 0x004FC87B File Offset: 0x004FAA7B
	private void SetSelected(bool selected, bool fireEvent = false)
	{
		base.GetExtendToggle(0).SetToggleState(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x0601223B RID: 74299 RVA: 0x004FC894 File Offset: 0x004FAA94
	private void OnToggleStateChange(EToggleState state)
	{
		Action<int> onToggleStateChangeFunction = this.OnToggleStateChangeFunction;
		if (onToggleStateChangeFunction == null)
		{
			return;
		}
		onToggleStateChangeFunction(this.CurrentId);
	}

	// Token: 0x04008D8D RID: 36237
	private PhantomManagerConfigNewElementItem ElementItem;

	// Token: 0x04008D8E RID: 36238
	private int CurrentId;

	// Token: 0x04008D8F RID: 36239
	public Func<int, bool> IsSelectOnCb;

	// Token: 0x04008D90 RID: 36240
	public Action<int> OnToggleStateChangeFunction;

	// Token: 0x0200879A RID: 34714
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402DD76 RID: 187766
		Toggle,
		// Token: 0x0402DD77 RID: 187767
		Txt,
		// Token: 0x0402DD78 RID: 187768
		PanelItem,
		// Token: 0x0402DD79 RID: 187769
		SpriteDone
	}
}
