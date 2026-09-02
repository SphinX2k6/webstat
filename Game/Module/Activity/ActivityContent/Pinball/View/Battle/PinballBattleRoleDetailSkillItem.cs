using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Battle
{
	// Token: 0x0200663E RID: 26174
	public class PinballBattleRoleDetailSkillItem : GridProxyAbstract<int>
	{
		// Token: 0x06041604 RID: 267780 RVA: 0x010C53E4 File Offset: 0x010C35E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041605 RID: 267781 RVA: 0x010C546E File Offset: 0x010C366E
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.Refresh(data);
		}

		// Token: 0x06041606 RID: 267782 RVA: 0x010C5478 File Offset: 0x010C3678
		public void Refresh(int data)
		{
			PinballSkillDisplayConfig? pinballSkillDisplayConfigById = ConfigBase<PinballConfig>.Instance.GetPinballSkillDisplayConfigById(data);
			if (pinballSkillDisplayConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Pinball;
				ELogAuthor author = ELogAuthor.CB;
				string message = "技能配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", data);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), pinballSkillDisplayConfigById.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), pinballSkillDisplayConfigById.Value.Desc, pinballSkillDisplayConfigById.Value.ValueList());
		}

		// Token: 0x0200C664 RID: 50788
		private enum EPinballBattleRoleDetailSkillItemComp
		{
			// Token: 0x0403D13E RID: 250174
			NameText,
			// Token: 0x0403D13F RID: 250175
			DescriptionText,
			// Token: 0x0403D140 RID: 250176
			SpriteIcon
		}
	}
}
