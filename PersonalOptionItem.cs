using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200242E RID: 9262
public class PersonalOptionItem : GridProxyAbstract<int>
{
	// Token: 0x06011E99 RID: 73369 RVA: 0x004ED3AE File Offset: 0x004EB5AE
	[NullableContext(1)]
	public PersonalOptionItem(UUIItem item)
	{
		if (item != null)
		{
			this.CreateThenShowByActor(item.GetOwner());
		}
	}

	// Token: 0x06011E9A RID: 73370 RVA: 0x004ED3C8 File Offset: 0x004EB5C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISpriteTransition));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickItem));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011E9B RID: 73371 RVA: 0x004ED4B0 File Offset: 0x004EB6B0
	public override void Refresh(int optionId, bool isSelected, int gridIndex)
	{
		this.OptionId = optionId;
		PersonalTips? config = ConfigPersonalTipsById.GetConfig(this.OptionId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "个性化弹窗配置找不到,id为";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("config!.Id", config.Value.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		base.GetText(1).ShowTextNew(config.Value.Description);
		UUISpriteTransition transition = base.GetUiSpriteTransition(2);
		Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(config.Value.IconPath, delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string path)
		{
			if (sprite.IsValid() && transition.IsValid())
			{
				transition.SetAllTransitionSprite(sprite);
			}
		}, 100, "js_undefined");
		if (config.Value.RedDotName != "")
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(Enum.Parse<ERedDotName>(config.Value.RedDotName), base.GetItem(3), null, 0);
		}
	}

	// Token: 0x06011E9C RID: 73372 RVA: 0x004ED5B2 File Offset: 0x004EB7B2
	private void OnClickItem()
	{
		this.ClickFunction = ControllerBase<PersonalOptionController>.Instance.GetOptionFunc((EPersonalOptionDefine)this.OptionId);
		this.ClickFunction();
	}

	// Token: 0x06011E9D RID: 73373 RVA: 0x004ED5D8 File Offset: 0x004EB7D8
	protected override void OnBeforeDestroy()
	{
		PersonalTips? config = ConfigPersonalTipsById.GetConfig(this.OptionId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "个性化弹窗配置找不到,id为";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("config!.Id", config.Value.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (config.Value.RedDotName != "")
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(Enum.Parse<ERedDotName>(config.Value.RedDotName), base.GetItem(3), 0);
		}
	}

	// Token: 0x04008C49 RID: 35913
	private int OptionId;

	// Token: 0x04008C4A RID: 35914
	[Nullable(2)]
	private Action ClickFunction;

	// Token: 0x02008766 RID: 34662
	private class EPersonalOptionItemDefine
	{
		// Token: 0x0402DC7A RID: 187514
		public const int Button = 0;

		// Token: 0x0402DC7B RID: 187515
		public const int Description = 1;

		// Token: 0x0402DC7C RID: 187516
		public const int Icon = 2;

		// Token: 0x0402DC7D RID: 187517
		public const int RedDot = 3;
	}
}
