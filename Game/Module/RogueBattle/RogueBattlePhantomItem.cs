using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005200 RID: 20992
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattlePhantomItem : GridProxyAbstract<RogueResGainData>
	{
		// Token: 0x06035DB8 RID: 220600 RVA: 0x00D8DC6C File Offset: 0x00D8BE6C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnClick))
			};
		}

		// Token: 0x06035DB9 RID: 220601 RVA: 0x00D8DD84 File Offset: 0x00D8BF84
		private void OnClick(EToggleState state)
		{
			if (this.SelectCallBack == null)
			{
				return;
			}
			if (base.GetExtendToggle(5).GetToggleState() == EToggleState.ETT_Checked)
			{
				this.SelectCallBack(new int?(base.GridIndex));
				return;
			}
			this.SelectCallBack(null);
		}

		// Token: 0x06035DBA RID: 220602 RVA: 0x00D8DDD4 File Offset: 0x00D8BFD4
		private RogueBattlePhantomAffix CreateAffixItem()
		{
			return new RogueBattlePhantomAffix();
		}

		// Token: 0x06035DBB RID: 220603 RVA: 0x00D8DDDC File Offset: 0x00D8BFDC
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattlePhantomItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattlePhantomItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035DBC RID: 220604 RVA: 0x00D8DE20 File Offset: 0x00D8C020
		public override void Refresh(RogueResGainData data, bool isSelected, int gridIndex)
		{
			RogueBattlePhantomItem.<>c__DisplayClass7_0 CS$<>8__locals1 = new RogueBattlePhantomItem.<>c__DisplayClass7_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			if (CS$<>8__locals1.data.RogueResPhantom == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RogueBattle;
				ELogAuthor author = ELogAuthor.LPH;
				string message = "不是声骸类型的数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", CS$<>8__locals1.data.RogueResDataType);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.Data = CS$<>8__locals1.data;
			RogueResPokemon? rogueResPokemon = ConfigBase<RogueBattleConfig>.Instance.GetRogueResPokemon(CS$<>8__locals1.data.RogueResPhantom.ConfigId);
			if (rogueResPokemon == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueResPokemon.Value.PokemonName, Array.Empty<object>());
			base.SetTextureByPath(rogueResPokemon.Value.PokemonIcon, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rogueResPokemon.Value.PokemonSkillDesc, Array.Empty<object>());
			base.GetText(2).SetUIActive(ModelBase<RogueBattleModel>.Instance.DescMode == EDescModel.DETAIL);
			RogueResQualityConfig? rogueResQualityConfig = ConfigBase<RogueBattleConfig>.Instance.GetRogueResQualityConfig(rogueResPokemon.Value.Quality);
			if (rogueResQualityConfig != null)
			{
				base.SetTextureByPath(rogueResQualityConfig.Value.PhantomBgA, base.GetTexture(6), null, null);
				base.SetTextureByPath(rogueResQualityConfig.Value.PhantomBgB, base.GetTexture(7), null, null);
			}
			UiAsyncTask task = new UiAsyncTask("RogueBattlePhantomItem.Refresh", delegate()
			{
				RogueBattlePhantomItem.<>c__DisplayClass7_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<RogueBattlePhantomItem.<>c__DisplayClass7_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x06035DBD RID: 220605 RVA: 0x00D8DFDA File Offset: 0x00D8C1DA
		public override void OnSelected(bool fireEvent)
		{
			ModelBase<RogueBattleModel>.Instance.SelectGainData = this.Data;
		}

		// Token: 0x06035DBE RID: 220606 RVA: 0x00D8DFEC File Offset: 0x00D8C1EC
		public override void OnDeselected(bool fireEvent)
		{
			ModelBase<RogueBattleModel>.Instance.SelectGainData = null;
		}

		// Token: 0x0401EECF RID: 126671
		[Nullable(2)]
		public Action<int?> SelectCallBack;

		// Token: 0x0401EED0 RID: 126672
		[Nullable(2)]
		public RogueResGainData Data;

		// Token: 0x0401EED1 RID: 126673
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<RogueBattlePhantomAffix, PhantomAffixInfo> AffixLayout;
	}
}
