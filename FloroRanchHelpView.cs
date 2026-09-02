using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EBC RID: 7868
public class FloroRanchHelpView : UiViewBase, IExtraUiPopFrameType
{
	// Token: 0x0600E897 RID: 59543 RVA: 0x003EE588 File Offset: 0x003EC788
	[NullableContext(1)]
	public FloroRanchHelpView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E898 RID: 59544 RVA: 0x003EE594 File Offset: 0x003EC794
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E899 RID: 59545 RVA: 0x003EE620 File Offset: 0x003EC820
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<FloroRanchHelpItem, HelpText>(base.GetVerticalLayout(1), () => new FloroRanchHelpItem(), null, false, true);
		int groupId = (int)this.OpenParam;
		IReadOnlyList<HelpText> helpContentInfoByGroupId = ConfigBase<HelpConfig>.Instance.GetHelpContentInfoByGroupId(groupId);
		if (helpContentInfoByGroupId != null)
		{
			this.Layout.RefreshByData(helpContentInfoByGroupId.ToList<HelpText>(), null, false);
			if (helpContentInfoByGroupId.Count > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), helpContentInfoByGroupId[0].Title, Array.Empty<object>());
			}
		}
	}

	// Token: 0x0600E89A RID: 59546 RVA: 0x003EE6BD File Offset: 0x003EC8BD
	[NullableContext(2)]
	public EUiBehaviourPopType? GetExtraPopFrameType(object param)
	{
		return new EUiBehaviourPopType?(EUiBehaviourPopType.FloroRanchHelp);
	}

	// Token: 0x0400700D RID: 28685
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<FloroRanchHelpItem, HelpText> Layout;

	// Token: 0x020081FF RID: 33279
	private enum EComponents
	{
		// Token: 0x0402C18F RID: 180623
		TextTitle,
		// Token: 0x0402C190 RID: 180624
		ItemContent,
		// Token: 0x0402C191 RID: 180625
		ItemText
	}
}
