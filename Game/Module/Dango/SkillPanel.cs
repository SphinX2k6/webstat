using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango
{
	// Token: 0x02005DE3 RID: 24035
	internal class SkillPanel : UiPanelBase
	{
		// Token: 0x0603C7EB RID: 247787 RVA: 0x00F5D29E File Offset: 0x00F5B49E
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x0603C7EC RID: 247788 RVA: 0x00F5D2D8 File Offset: 0x00F5B4D8
		[NullableContext(1)]
		public void Refresh(AbyssDangoRoleData data)
		{
			if (this.SkillType == ESkillShowType.Skill)
			{
				string skillDesc = data.GetSkillDesc();
				string[] skillDescAddition = data.GetSkillDescAddition();
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), skillDesc, skillDescAddition.ToArray<string>());
				this.SetActive(true);
				return;
			}
			string[] effectPassiveSkillDescList = data.GetEffectPassiveSkillDescList();
			string text = string.Empty;
			int num = effectPassiveSkillDescList.Length;
			for (int i = 0; i < num; i++)
			{
				text = text + effectPassiveSkillDescList[i] + ((i != num - 1) ? "\n\n" : string.Empty);
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetText(text, true);
			}
			this.SetActive(effectPassiveSkillDescList.Length != 0);
		}

		// Token: 0x0402203A RID: 139322
		public ESkillShowType SkillType;
	}
}
