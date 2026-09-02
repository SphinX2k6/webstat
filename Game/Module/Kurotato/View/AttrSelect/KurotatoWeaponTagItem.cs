using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005AD5 RID: 23253
	public class KurotatoWeaponTagItem : UiPanelBase
	{
		// Token: 0x0603ACAE RID: 240814 RVA: 0x00EE8A74 File Offset: 0x00EE6C74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickTag));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603ACAF RID: 240815 RVA: 0x00EE8B7D File Offset: 0x00EE6D7D
		private void OnClickTag(EToggleState state)
		{
			Action<List<IKurotatoWeaponBuildData>, EToggleState> clickCb = this.ClickCb;
			if (clickCb == null)
			{
				return;
			}
			clickCb(this.DataList, state);
		}

		// Token: 0x0603ACB0 RID: 240816 RVA: 0x00EE8B98 File Offset: 0x00EE6D98
		[NullableContext(1)]
		public void Refresh(List<IKurotatoWeaponBuildData> dataList)
		{
			this.DataList = dataList;
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoModel instance2 = ModelBase<KurotatoModel>.Instance;
			IKurotatoWeaponBuildData kurotatoWeaponBuildData = dataList[0];
			string text = ConfigMultiTextLang.GetLocalTextNew(instance.GetWeaponBuildById(kurotatoWeaponBuildData.BuildId).Value.Name, null) ?? "";
			int weaponBuildLevelByBuildId = instance2.GetWeaponBuildLevelByBuildId(kurotatoWeaponBuildData.BuildId);
			string text2;
			if (!this.IsOutside)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
				defaultInterpolatedStringHandler.AppendFormatted(text);
				defaultInterpolatedStringHandler.AppendLiteral(" (");
				defaultInterpolatedStringHandler.AppendFormatted<int>(weaponBuildLevelByBuildId);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				text2 = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				text2 = text;
			}
			string newText = text2;
			base.GetText(1).SetText(newText, true);
			bool flag = dataList.Count > 1;
			base.GetText(3).SetUIActive(flag);
			base.GetSprite(4).SetUIActive(flag);
			if (flag)
			{
				IKurotatoWeaponBuildData kurotatoWeaponBuildData2 = dataList[1];
				string text3 = ConfigMultiTextLang.GetLocalTextNew(instance.GetWeaponBuildById(kurotatoWeaponBuildData2.BuildId).Value.Name, null) ?? "";
				int weaponBuildLevelByBuildId2 = instance2.GetWeaponBuildLevelByBuildId(kurotatoWeaponBuildData2.BuildId);
				string text4;
				if (!this.IsOutside)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
					defaultInterpolatedStringHandler.AppendFormatted(text3);
					defaultInterpolatedStringHandler.AppendLiteral(" (");
					defaultInterpolatedStringHandler.AppendFormatted<int>(weaponBuildLevelByBuildId2);
					defaultInterpolatedStringHandler.AppendLiteral(")");
					text4 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					text4 = text3;
				}
				string newText2 = text4;
				base.GetText(3).SetText(newText2, true);
			}
		}

		// Token: 0x0603ACB1 RID: 240817 RVA: 0x00EE8D20 File Offset: 0x00EE6F20
		[NullableContext(1)]
		public void SetClickCb(Action<List<IKurotatoWeaponBuildData>, EToggleState> cb)
		{
			this.ClickCb = cb;
		}

		// Token: 0x0603ACB2 RID: 240818 RVA: 0x00EE8D2C File Offset: 0x00EE6F2C
		public void SetChecked(bool isChecked)
		{
			EToggleState state = isChecked ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(2).SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x0603ACB3 RID: 240819 RVA: 0x00EE8D51 File Offset: 0x00EE6F51
		public bool IsChecked()
		{
			return base.GetExtendToggle(2).GetToggleState() == EToggleState.ETT_Checked;
		}

		// Token: 0x0603ACB4 RID: 240820 RVA: 0x00EE8D62 File Offset: 0x00EE6F62
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IKurotatoWeaponBuildData> GetDataList()
		{
			return this.DataList;
		}

		// Token: 0x040213A5 RID: 136101
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IKurotatoWeaponBuildData> DataList;

		// Token: 0x040213A6 RID: 136102
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<List<IKurotatoWeaponBuildData>, EToggleState> ClickCb;

		// Token: 0x040213A7 RID: 136103
		public bool IsOutside;

		// Token: 0x0200BB00 RID: 47872
		private class ETagChildComp
		{
			// Token: 0x04039B81 RID: 236417
			public const int PanelOffset = 0;

			// Token: 0x04039B82 RID: 236418
			public const int TextName = 1;

			// Token: 0x04039B83 RID: 236419
			public const int Toggle = 2;

			// Token: 0x04039B84 RID: 236420
			public const int TextName2 = 3;

			// Token: 0x04039B85 RID: 236421
			public const int SpriteLine = 4;
		}
	}
}
