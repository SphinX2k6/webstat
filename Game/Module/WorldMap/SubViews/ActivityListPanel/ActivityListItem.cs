using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.ActivityListPanel
{
	// Token: 0x02004BE2 RID: 19426
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ActivityListItem : GridProxyAbstract<ActivityListPanelItemData>
	{
		// Token: 0x06032AF1 RID: 207601 RVA: 0x00CB15DC File Offset: 0x00CAF7DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.ReadPoint, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.TextTitle, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.TextTime, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.TextDescription, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.Icon, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.TextValue, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.ActivityIcon, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.FinishedIcon, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.UpIcon, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.DoubleUpIcon, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(ActivityListItem.EChildType.Toggle, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(ActivityListItem.EChildType.Toggle, new Action<EToggleState>(this.OnToggleClickInternal));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032AF2 RID: 207602 RVA: 0x00CB17DC File Offset: 0x00CAF9DC
		public override void Refresh(ActivityListPanelItemData data, bool isSelected, int gridIndex)
		{
			this.DataParam = data.Data;
			this.OnClickCb = data.OnClickCb;
			this.RefreshReadPoint();
			this.RefreshInfo();
		}

		// Token: 0x06032AF3 RID: 207603 RVA: 0x00CB1802 File Offset: 0x00CAFA02
		public void RefreshReadPoint()
		{
			base.GetItem(ActivityListItem.EChildType.ReadPoint).SetUIActive(this.DataParam.RedPoint);
		}

		// Token: 0x06032AF4 RID: 207604 RVA: 0x00CB181F File Offset: 0x00CAFA1F
		public EMapPeriodicActivityId GetMapPeriodicActivityId()
		{
			return this.DataParam.Id;
		}

		// Token: 0x06032AF5 RID: 207605 RVA: 0x00CB182C File Offset: 0x00CAFA2C
		public void RefreshInfo()
		{
			MapPeriodicActivity? mapPeriodicActivityConfig = ConfigBase<MapConfig>.Instance.GetMapPeriodicActivityConfig(this.DataParam.Id);
			base.GetText(ActivityListItem.EChildType.TextTitle).ShowTextNew(((mapPeriodicActivityConfig != null) ? mapPeriodicActivityConfig.GetValueOrDefault().TitleKey : null) ?? "");
			base.GetText(ActivityListItem.EChildType.TextDescription).ShowTextNew(((mapPeriodicActivityConfig != null) ? mapPeriodicActivityConfig.GetValueOrDefault().DescriptionKey : null) ?? "");
			this.SetSpriteByPath(mapPeriodicActivityConfig.Value.IconPath, base.GetSprite(ActivityListItem.EChildType.ActivityIcon), true, null, null);
			base.GetText(ActivityListItem.EChildType.TextTime).SetText(this.DataParam.LeftTimeText, true);
			UUIText text = base.GetText(ActivityListItem.EChildType.TextValue);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.DataParam.CurrentNum);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.DataParam.TotalNum);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			base.GetItem(ActivityListItem.EChildType.Icon).SetUIActive(false);
			base.GetSprite(ActivityListItem.EChildType.FinishedIcon).SetUIActive(this.DataParam.IsFinish);
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("MapPeriodicActivityTime").GetValueOrDefault();
			double leftTime = this.DataParam.LeftTime;
			UUIText text2 = base.GetText(ActivityListItem.EChildType.TextTime);
			UUIItem uuiitem = text2;
			bool bUseChangeColor = leftTime > 0.0 && leftTime <= (double)valueOrDefault;
			FColor? fcolor = new FColor?(text2.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x06032AF6 RID: 207606 RVA: 0x00CB19D7 File Offset: 0x00CAFBD7
		private void OnToggleClickInternal(EToggleState toggleState)
		{
			Action onClickCb = this.DataParam.OnClickCb;
			if (onClickCb != null)
			{
				onClickCb();
			}
			Action onClickCb2 = this.OnClickCb;
			if (onClickCb2 != null)
			{
				onClickCb2();
			}
			base.GetExtendToggle(ActivityListItem.EChildType.Toggle).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0401D82F RID: 120879
		private IActivityListItemData DataParam;

		// Token: 0x0401D830 RID: 120880
		[Nullable(2)]
		private Action OnClickCb;

		// Token: 0x0200ACC9 RID: 44233
		[NullableContext(0)]
		public static class EChildType
		{
			// Token: 0x04035AB5 RID: 219829
			public static readonly int Toggle = 0;

			// Token: 0x04035AB6 RID: 219830
			public static readonly int ReadPoint = 1;

			// Token: 0x04035AB7 RID: 219831
			public static readonly int TextTitle = 2;

			// Token: 0x04035AB8 RID: 219832
			public static readonly int TextTime = 3;

			// Token: 0x04035AB9 RID: 219833
			public static readonly int TextDescription = 4;

			// Token: 0x04035ABA RID: 219834
			public static readonly int Icon = 5;

			// Token: 0x04035ABB RID: 219835
			public static readonly int TextValue = 6;

			// Token: 0x04035ABC RID: 219836
			public static readonly int ActivityIcon = 7;

			// Token: 0x04035ABD RID: 219837
			public static readonly int FinishedIcon = 8;

			// Token: 0x04035ABE RID: 219838
			public static readonly int UpIcon = 9;

			// Token: 0x04035ABF RID: 219839
			public static readonly int DoubleUpIcon = 10;
		}
	}
}
