using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001CF1 RID: 7409
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GachaTagItem : GridProxyAbstract<GachaPoolData>
{
	// Token: 0x1700114F RID: 4431
	// (get) Token: 0x0600D980 RID: 55680 RVA: 0x003A5605 File Offset: 0x003A3805
	public int GachaId
	{
		get
		{
			return this.Data.GachaInfo.Id;
		}
	}

	// Token: 0x0600D981 RID: 55681 RVA: 0x003A5618 File Offset: 0x003A3818
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.TagToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D982 RID: 55682 RVA: 0x003A5763 File Offset: 0x003A3963
	protected override void OnStart()
	{
		base.GetExtendToggle(3).CanExecuteChange.Bind(() => this.CanExecuteChange == null || this.CanExecuteChange(base.GridIndex));
	}

	// Token: 0x0600D983 RID: 55683 RVA: 0x003A5782 File Offset: 0x003A3982
	private void TagToggle(EToggleState toggleState)
	{
		Action<int> selectCallback = this.SelectCallback;
		if (selectCallback == null)
		{
			return;
		}
		selectCallback(base.GridIndex);
	}

	// Token: 0x0600D984 RID: 55684 RVA: 0x003A579C File Offset: 0x003A399C
	public void SetSelected(bool selected)
	{
		if (selected)
		{
			base.GetExtendToggle(3).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			OnClickGachaScrollLogEvent onClickGachaScrollLogEvent = new OnClickGachaScrollLogEvent();
			onClickGachaScrollLogEvent.i_gacha_id = this.GachaId;
			ControllerBase<LogReportController>.Instance.LogReport(onClickGachaScrollLogEvent);
			return;
		}
		base.GetExtendToggle(3).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600D985 RID: 55685 RVA: 0x003A57EC File Offset: 0x003A39EC
	public void RefreshRedDot()
	{
		bool flag = ModelBase<GachaModel>.Instance.CheckNewGachaPoolById(this.GachaId);
		if (!flag)
		{
			ProtoGachaInfo gachaInfo = ModelBase<GachaModel>.Instance.GetGachaInfo(this.GachaId);
			ProtoGachaPoolInfo protoGachaPoolInfo = (gachaInfo != null) ? gachaInfo.GetFirstValidPool() : null;
			if (protoGachaPoolInfo != null && protoGachaPoolInfo.UiType == 5)
			{
				bool flag2 = gachaInfo != null && gachaInfo.UsePoolId == 0;
				bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.FirstOpenCommonWeaponSelect, false);
				flag = (flag2 && !player);
			}
			int accumulateId = (gachaInfo != null) ? gachaInfo.GachaAccumulateId : 0;
			GachaAccumulateData accumulateData = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(accumulateId);
			if (accumulateData != null && accumulateData.HasClaimable)
			{
				flag = accumulateData.HasClaimable;
			}
		}
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(flag);
	}

	// Token: 0x0600D986 RID: 55686 RVA: 0x003A58A4 File Offset: 0x003A3AA4
	public void InitData()
	{
		if (this.Data == null)
		{
			return;
		}
		int id = this.Data.PoolInfo.Id;
		GachaViewInfo? gachaViewInfo = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(id);
		if (gachaViewInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Gacha;
			ELogAuthor author = ELogAuthor.LPH;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 1);
			defaultInterpolatedStringHandler.AppendLiteral("获取抽卡界面信息失败，请检查GachaViewInfo表，GachaId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.GachaId);
			instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.SetSpriteByPath(gachaViewInfo.Value.TagNotSelectedSpritePath, base.GetSprite(0), false, null, null);
		this.SetSpriteByPath(gachaViewInfo.Value.TagSelectedSpritePath, base.GetSprite(1), false, null, null);
		base.GetItem(4).SetUIActive(true);
		int type = gachaViewInfo.Value.Type;
		GachaViewTypeInfo? gachaViewTypeConfig = ConfigBase<GachaConfig>.Instance.GetGachaViewTypeConfig(type);
		string tagText = gachaViewTypeConfig.Value.TagText;
		if (tagText != null && !StringUtils.IsBlank(tagText))
		{
			base.GetItem(4).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), gachaViewTypeConfig.Value.TagText, Array.Empty<object>());
			FColor color = FColor.FromHex(gachaViewTypeConfig.Value.TagColor);
			base.GetSprite(5).SetColor(color);
			return;
		}
		base.GetItem(4).SetUIActive(false);
	}

	// Token: 0x0600D987 RID: 55687 RVA: 0x003A5A27 File Offset: 0x003A3C27
	[NullableContext(1)]
	public override void Refresh(GachaPoolData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.InitData();
		this.RefreshRedDot();
		if (isSelected)
		{
			this.OnSelected(false);
			return;
		}
		this.OnDeselected(false);
	}

	// Token: 0x0600D988 RID: 55688 RVA: 0x003A5A4E File Offset: 0x003A3C4E
	[NullableContext(1)]
	public override object GetKey(GachaPoolData data, int displayIndex)
	{
		return this.GachaId;
	}

	// Token: 0x0600D989 RID: 55689 RVA: 0x003A5A5B File Offset: 0x003A3C5B
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true);
	}

	// Token: 0x0600D98A RID: 55690 RVA: 0x003A5A64 File Offset: 0x003A3C64
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false);
	}

	// Token: 0x040067CF RID: 26575
	public GachaPoolData Data;

	// Token: 0x040067D0 RID: 26576
	public Action<int> SelectCallback;

	// Token: 0x040067D1 RID: 26577
	public Func<int, bool> CanExecuteChange;

	// Token: 0x0200805B RID: 32859
	[NullableContext(0)]
	private enum EGachaTagCom
	{
		// Token: 0x0402BA9D RID: 178845
		ContentNotSelectedSprite,
		// Token: 0x0402BA9E RID: 178846
		ContentSelectedSprite,
		// Token: 0x0402BA9F RID: 178847
		RedDotItem,
		// Token: 0x0402BAA0 RID: 178848
		TagToggle,
		// Token: 0x0402BAA1 RID: 178849
		TipItem,
		// Token: 0x0402BAA2 RID: 178850
		TipBgSprite,
		// Token: 0x0402BAA3 RID: 178851
		TipText
	}
}
