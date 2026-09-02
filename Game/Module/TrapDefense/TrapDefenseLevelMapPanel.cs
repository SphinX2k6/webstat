using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E2D RID: 20013
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseLevelMapPanel : UiPanelBase
	{
		// Token: 0x06033BC2 RID: 211906 RVA: 0x00CEED48 File Offset: 0x00CECF48
		public UniTask Init(UUIItem item)
		{
			TrapDefenseLevelMapPanel.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseLevelMapPanel.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033BC3 RID: 211907 RVA: 0x00CEED93 File Offset: 0x00CECF93
		protected override void OnBeforeCreate()
		{
		}

		// Token: 0x06033BC4 RID: 211908 RVA: 0x00CEED98 File Offset: 0x00CECF98
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnMonsterDesc));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033BC5 RID: 211909 RVA: 0x00CEEE80 File Offset: 0x00CED080
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseLevelMapPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseLevelMapPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033BC6 RID: 211910 RVA: 0x00CEEEC3 File Offset: 0x00CED0C3
		protected override void OnStart()
		{
		}

		// Token: 0x06033BC7 RID: 211911 RVA: 0x00CEEEC5 File Offset: 0x00CED0C5
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06033BC8 RID: 211912 RVA: 0x00CEEEC7 File Offset: 0x00CED0C7
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033BC9 RID: 211913 RVA: 0x00CEEECC File Offset: 0x00CED0CC
		public void UpdateData(TrapDefenseLevelData data)
		{
			this.LevelData = data;
			UUITexture uiMap = base.GetTexture(0);
			base.SetTextureByPath(data.GetPreviewMapResource(), uiMap, null, delegate(bool ret)
			{
				if (ret)
				{
					uiMap.SetSizeFromTexture();
				}
			});
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.ShowTextNew(ETrapDefenseTextKey.LevelDescTitle.ToString());
			}
			UUIText text2 = base.GetText(3);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, data.Config.DifficultyDesc, data.Config.DifficultyDescArgs());
		}

		// Token: 0x06033BCA RID: 211914 RVA: 0x00CEEF68 File Offset: 0x00CED168
		public void OnClickBtnMonsterDesc()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewMonster(new int?(this.LevelData.Config.InstId), null, new bool?(this.IsInstance));
		}

		// Token: 0x0401DF32 RID: 122674
		public TrapDefenseLevelData LevelData;

		// Token: 0x0401DF33 RID: 122675
		public bool IsInstance;

		// Token: 0x0200ADA8 RID: 44456
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035EDD RID: 220893
			public const int TextureMap = 0;

			// Token: 0x04035EDE RID: 220894
			public const int BtnMonsterDesc = 1;

			// Token: 0x04035EDF RID: 220895
			public const int TextTitle = 2;

			// Token: 0x04035EE0 RID: 220896
			public const int TextDesc = 3;
		}
	}
}
