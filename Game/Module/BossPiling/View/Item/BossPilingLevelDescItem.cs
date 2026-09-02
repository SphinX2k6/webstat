using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F0B RID: 24331
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BossPilingLevelDescItem : GridProxyAbstract<BossPilingLevelDescInfo>
	{
		// Token: 0x0603D1BD RID: 250301 RVA: 0x00F85C48 File Offset: 0x00F83E48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D1BE RID: 250302 RVA: 0x00F85D94 File Offset: 0x00F83F94
		[NullableContext(1)]
		public override void Refresh(BossPilingLevelDescInfo data, bool isSelected, int gridIndex)
		{
			this.IsFirstLevel = data.IsFirstLevel;
			string key = data.IsFirstLevel ? "BossPilingActivity_DungeonDetail05" : "BossPilingActivity_DungeonDetail07";
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(key);
			}
			UUIText text2 = base.GetText(2);
			if (text2 != null)
			{
				text2.ShowTextNew(data.LevelMechanism);
			}
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("BossPilingActivity_DungeonDetail17");
			if (StringUtils.IsBlank(data.MonsterDesc))
			{
				UUIText text3 = base.GetText(5);
				if (text3 != null)
				{
					text3.SetUIActive(false);
				}
				string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("BossPilingActivity_DungeonDetail09");
				UUIText text4 = base.GetText(3);
				if (text4 != null)
				{
					text4.SetText(configTextByKey2 + ": " + configTextByKey, true);
				}
			}
			else
			{
				UUIText text5 = base.GetText(5);
				if (text5 != null)
				{
					text5.SetUIActive(true);
				}
				UUIText text6 = base.GetText(5);
				if (text6 != null)
				{
					text6.ShowTextNew(data.MonsterDesc);
				}
				UUIText text7 = base.GetText(3);
				if (text7 != null)
				{
					text7.ShowTextNew("BossPilingActivity_DungeonDetail09");
				}
			}
			if (StringUtils.IsBlank(data.LevelDesc))
			{
				UUIText text8 = base.GetText(6);
				if (text8 != null)
				{
					text8.SetUIActive(false);
				}
				string configTextByKey3 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("BossPilingActivity_DungeonDetail10");
				UUIText text9 = base.GetText(4);
				if (text9 == null)
				{
					return;
				}
				text9.SetText(configTextByKey3 + configTextByKey, true);
				return;
			}
			else
			{
				UUIText text10 = base.GetText(6);
				if (text10 != null)
				{
					text10.SetUIActive(true);
				}
				UUIText text11 = base.GetText(6);
				if (text11 != null)
				{
					text11.ShowTextNew(data.LevelDesc);
				}
				UUIText text12 = base.GetText(4);
				if (text12 == null)
				{
					return;
				}
				text12.ShowTextNew("BossPilingActivity_DungeonDetail10");
				return;
			}
		}

		// Token: 0x0603D1BF RID: 250303 RVA: 0x00F85F1B File Offset: 0x00F8411B
		private void OnClickedBtn()
		{
			Action<bool> onClickedCb = this.OnClickedCb;
			if (onClickedCb == null)
			{
				return;
			}
			onClickedCb(this.IsFirstLevel);
		}

		// Token: 0x04022455 RID: 140373
		[Nullable(2)]
		public Action<bool> OnClickedCb;

		// Token: 0x04022456 RID: 140374
		public bool IsFirstLevel = true;

		// Token: 0x0200BF0B RID: 48907
		private enum EDefine
		{
			// Token: 0x0403ACD9 RID: 240857
			TxtTitle,
			// Token: 0x0403ACDA RID: 240858
			BtnView,
			// Token: 0x0403ACDB RID: 240859
			TxtLevelMechanism,
			// Token: 0x0403ACDC RID: 240860
			TxtBossTitle,
			// Token: 0x0403ACDD RID: 240861
			TxtLevelTitle,
			// Token: 0x0403ACDE RID: 240862
			TxtBoss,
			// Token: 0x0403ACDF RID: 240863
			TxtLevel
		}
	}
}
