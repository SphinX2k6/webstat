using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002AB3 RID: 10931
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SubPackageDownLoadMobileClearItem : GridProxyAbstract<ISubPackageDownLoadMobileClearData>
{
	// Token: 0x06015DF9 RID: 89593 RVA: 0x00612890 File Offset: 0x00610A90
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06015DFA RID: 89594 RVA: 0x006128EC File Offset: 0x00610AEC
	protected override UniTask OnBeforeStartAsync()
	{
		SubPackageDownLoadMobileClearItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SubPackageDownLoadMobileClearItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015DFB RID: 89595 RVA: 0x0061292F File Offset: 0x00610B2F
	private SubPackageDownLoadMobileClearInfoItem InitInfoItem()
	{
		return new SubPackageDownLoadMobileClearInfoItem
		{
			OnClickToggleCallBack = this.OnClickToggleCallBack
		};
	}

	// Token: 0x06015DFC RID: 89596 RVA: 0x00612944 File Offset: 0x00610B44
	public override void Refresh(ISubPackageDownLoadMobileClearData data, bool isSelected, int gridIndex)
	{
		SubPackageDownLoadMobileClearTitleItem titleItem = this.TitleItem;
		if (titleItem != null)
		{
			titleItem.RefreshItem(data.TitleId);
		}
		SubPackageDownLoadMobileClearTitleItem titleItem2 = this.TitleItem;
		if (titleItem2 != null)
		{
			titleItem2.SetUiActive(true);
		}
		List<ISubPackageDownLoadMobileClearInfoItemData> list = new List<ISubPackageDownLoadMobileClearInfoItemData>();
		if (data.TitleId == 3)
		{
			ISubPackageDownLoadMobileClearInfoItemData item = new SubPackageDownLoadMobileClearInfoItemData
			{
				Type = ESubPackageDownLoadPackageType.OptionalPlot,
				HaveVideoCanClear = data.HaveVideoCanClear
			};
			list.Add(item);
		}
		else
		{
			if (data.TitleId == 2)
			{
				using (List<int>.Enumerator enumerator = (data.SceneIdList ?? new List<int>()).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int value = enumerator.Current;
						ISubPackageDownLoadMobileClearInfoItemData item2 = new SubPackageDownLoadMobileClearInfoItemData
						{
							Type = ESubPackageDownLoadPackageType.OptionalScene,
							SceneId = new int?(value)
						};
						list.Add(item2);
					}
					goto IL_121;
				}
			}
			if (data.TitleId == 5)
			{
				foreach (string voiceLanguageCode in (data.VoiceLanguageCodeList ?? new List<string>()))
				{
					ISubPackageDownLoadMobileClearInfoItemData item3 = new SubPackageDownLoadMobileClearInfoItemData
					{
						Type = ESubPackageDownLoadPackageType.Voice,
						VoiceLanguageCode = voiceLanguageCode
					};
					list.Add(item3);
				}
			}
		}
		IL_121:
		GenericLayout<SubPackageDownLoadMobileClearInfoItem, ISubPackageDownLoadMobileClearInfoItemData> infoItemLayout = this.InfoItemLayout;
		if (infoItemLayout == null)
		{
			return;
		}
		infoItemLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0400A7EA RID: 42986
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, UUIItem> OnClickHelpBtnCallBack;

	// Token: 0x0400A7EB RID: 42987
	[Nullable(2)]
	public Action<int?, bool, EToggleState, string> OnClickToggleCallBack;

	// Token: 0x0400A7EC RID: 42988
	[Nullable(2)]
	private SubPackageDownLoadMobileClearTitleItem TitleItem;

	// Token: 0x0400A7ED RID: 42989
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SubPackageDownLoadMobileClearInfoItem, ISubPackageDownLoadMobileClearInfoItemData> InfoItemLayout;

	// Token: 0x02008E20 RID: 36384
	[NullableContext(0)]
	private class ESubPackageDownLoadMobileClearItem
	{
		// Token: 0x0402FD05 RID: 195845
		public const int TitleItem = 0;

		// Token: 0x0402FD06 RID: 195846
		public const int InfoLayout = 1;

		// Token: 0x0402FD07 RID: 195847
		public const int InfoItem = 2;
	}
}
