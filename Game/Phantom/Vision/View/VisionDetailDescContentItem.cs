using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Phantom.Vision.View
{
	// Token: 0x02004A6F RID: 19055
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class VisionDetailDescContentItem : GridProxyAbstract<VisionDetailDesc>
	{
		// Token: 0x06031BF2 RID: 203762 RVA: 0x00C74CC8 File Offset: 0x00C72EC8
		public override void Refresh(VisionDetailDesc data, bool isSelected, int gridIndex)
		{
			this.Update(data);
		}

		// Token: 0x06031BF3 RID: 203763 RVA: 0x00C74CD4 File Offset: 0x00C72ED4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06031BF4 RID: 203764 RVA: 0x00C74E6C File Offset: 0x00C7306C
		protected override UniTask OnBeforeStartAsync()
		{
			VisionDetailDescContentItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VisionDetailDescContentItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031BF5 RID: 203765 RVA: 0x00C74EAF File Offset: 0x00C730AF
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetItem(7));
		}

		// Token: 0x06031BF6 RID: 203766 RVA: 0x00C74EC4 File Offset: 0x00C730C4
		public void Update(VisionDetailDesc data)
		{
			this.Data = data;
			if (this.Data == null)
			{
				return;
			}
			this.RefreshActiveContentItem(data);
			this.RefreshActiveStateItem(data);
			this.RefreshContent(data);
			this.RefreshElement(data);
			this.RefreshNoneItem(data);
			this.RefreshAnimation(data);
			this.RefreshSimplyAnimation(data);
		}

		// Token: 0x06031BF7 RID: 203767 RVA: 0x00C74F14 File Offset: 0x00C73114
		private void RefreshSimplyAnimation(VisionDetailDesc data)
		{
			if (data.NeedSimplyStateChangeAnimation && data.AnimationState)
			{
				this.LevelSequencePlayer.StopSequenceByKey("Switch", false, true);
				this.LevelSequencePlayer.PlayLevelSequenceByName("Switch", false, null, false);
			}
		}

		// Token: 0x06031BF8 RID: 203768 RVA: 0x00C74F60 File Offset: 0x00C73160
		private void RefreshAnimation(VisionDetailDesc data)
		{
			if (this.AnimationState && data.AnimationState)
			{
				string text = null;
				bool flag = false;
				if (data.GreenActiveState && data.NewState && data.FetterId > 0)
				{
					text = "Choose";
					flag = true;
				}
				if (data.FetterId > 0 && !flag && data.FetterData.ActiveState)
				{
					text = "Activate";
				}
				string currentSequence = this.LevelSequencePlayer.GetCurrentSequence();
				if (currentSequence != null && text != currentSequence)
				{
					this.LevelSequencePlayer.StopSequenceByKey(currentSequence, false, true);
				}
				if (text != null)
				{
					if (text != currentSequence)
					{
						this.LevelSequencePlayer.PlayLevelSequenceByName(text, false, null, false);
					}
					else
					{
						this.LevelSequencePlayer.ReplaySequenceByKey(text);
					}
				}
				UUIItem item = base.GetItem(10);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(data.GetNeedWarn() && !data.GetIsFetterData() && text == null);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(10);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(data.GetNeedWarn() && !data.GetIsFetterData());
				return;
			}
		}

		// Token: 0x06031BF9 RID: 203769 RVA: 0x00C7506E File Offset: 0x00C7326E
		private void RefreshActiveStateItem(VisionDetailDesc data)
		{
			base.GetItem(0).SetUIActive(data.NeedActiveState || data.GetNeedWarn());
		}

		// Token: 0x06031BFA RID: 203770 RVA: 0x00C7508D File Offset: 0x00C7328D
		private void RefreshActiveContentItem(VisionDetailDesc data)
		{
			if (data.NeedActiveState)
			{
				base.GetItem(2).SetUIActive(data.GreenActiveState);
				return;
			}
			if (data.GetNeedWarn())
			{
				base.GetItem(2).SetUIActive(false);
			}
		}

		// Token: 0x06031BFB RID: 203771 RVA: 0x00C750C0 File Offset: 0x00C732C0
		private void RefreshNoneItem(VisionDetailDesc data)
		{
			if (data.GreenActiveState && !data.NewState && data.FetterId > 0)
			{
				base.GetItem(1).SetUIActive(false);
				return;
			}
			if (data.GetNeedWarn() && !data.GetIsFetterData())
			{
				base.GetItem(1).SetUIActive(false);
				return;
			}
			if (data.GreenActiveState && data.SkillConfig != null)
			{
				base.GetItem(1).SetUIActive(false);
				return;
			}
			base.GetItem(1).SetUIActive(true);
		}

		// Token: 0x06031BFC RID: 203772 RVA: 0x00C75144 File Offset: 0x00C73344
		private void RefreshElement(VisionDetailDesc data)
		{
			if (data.FetterId > 0)
			{
				base.GetItem(5).SetUIActive(true);
				PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data.FetterGroupId);
				this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
				int num = (data.FetterData.ActiveFetterGroupNum > data.FetterData.NeedActiveNum) ? data.FetterData.NeedActiveNum : data.FetterData.ActiveFetterGroupNum;
				if (data.EquipOverNeed)
				{
					num = data.FetterData.ActiveFetterGroupNum;
				}
				string newText = StringUtils.Format("({0}/{1})", new string[]
				{
					num.ToString(),
					data.FetterData.NeedActiveNum.ToString()
				});
				string hexStr;
				if (data.FetterData.ActiveState)
				{
					hexStr = "E0D799FF";
				}
				else
				{
					hexStr = "F9FFFF6F";
				}
				base.GetText(9).SetText(newText, true);
				base.GetText(9).SetColor(FColor.FromHex(hexStr));
				return;
			}
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x06031BFD RID: 203773 RVA: 0x00C75250 File Offset: 0x00C73450
		private void RefreshContent(VisionDetailDesc data)
		{
			if (data.GetNeedWarn() && data.FetterId <= 0)
			{
				UUIText text = base.GetText(6);
				base.GetItem(8).SetUIActive(false);
				text.SetUIActive(true);
				base.GetText(4).SetUIActive(false);
				text.SetColor(FColor.FromHex("F9FFFF6F"));
				string textStringId = data.EquipSameMonster ? "SameVisionNoCountValue" : "OverNeedWarnText";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
				return;
			}
			bool flag = ModelBase<PhantomBattleModel>.Instance.GetIfSimpleState(1);
			flag = !flag;
			if (data.DoNotNeedCheckSimplyState)
			{
				flag = true;
			}
			if (data.FetterId > 0)
			{
				PhantomFetter phantomFetterById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterById(data.FetterId);
				string newText = ConfigMultiTextLang.GetLocalTextNew(phantomFetterById.Name, null) ?? "";
				base.GetText(4).SetText(newText, true);
				if (flag)
				{
					if (StringUtils.IsEmpty(phantomFetterById.SimplyEffectDesc))
					{
						base.GetText(6).SetText("", true);
					}
					else
					{
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), phantomFetterById.SimplyEffectDesc, Array.Empty<object>());
					}
				}
				else
				{
					int effectDescriptionParamLength = phantomFetterById.EffectDescriptionParamLength;
					object[] array = new object[effectDescriptionParamLength];
					for (int i = 0; i < effectDescriptionParamLength; i++)
					{
						array[i] = phantomFetterById.EffectDescriptionParam(i);
					}
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), phantomFetterById.EffectDescription, array);
				}
				base.GetText(4).SetUIActive(true);
				base.GetText(6).SetUIActive(true);
				if (data.GetNeedCheckChangeColor())
				{
					string hexStr;
					if (data.FetterData.ActiveState)
					{
						hexStr = "E0D799FF";
					}
					else
					{
						hexStr = "F9FFFF6F";
					}
					base.GetText(4).SetColor(FColor.FromHex(hexStr));
					base.GetText(6).SetColor(FColor.FromHex(hexStr));
					return;
				}
			}
			else if (data.SkillConfig != null)
			{
				if (flag)
				{
					if (StringUtils.IsEmpty(data.SkillConfig.Value.SimplyDescription))
					{
						base.GetText(6).SetText("", true);
					}
					else
					{
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), data.SkillConfig.Value.SimplyDescription, Array.Empty<object>());
					}
				}
				else
				{
					string[] phantomSkillDescExBySkillIdAndQuality = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExBySkillIdAndQuality(data.SkillConfig.Value.Id, data.Quality);
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), data.SkillConfig.Value.DescriptionEx, phantomSkillDescExBySkillIdAndQuality);
				}
				base.GetItem(8).SetUIActive(false);
				base.GetText(6).SetUIActive(true);
				if (data.GetNeedCheckChangeColor())
				{
					string hexStr2 = "F9FFFF6F";
					if (data.IfMainPosition)
					{
						hexStr2 = "E0D799FF";
					}
					base.GetText(6).SetColor(FColor.FromHex(hexStr2));
				}
			}
		}

		// Token: 0x06031BFE RID: 203774 RVA: 0x00C75532 File Offset: 0x00C73732
		protected override void OnBeforeHide()
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
		}

		// Token: 0x0401D20F RID: 119311
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401D210 RID: 119312
		private readonly bool AnimationState = true;

		// Token: 0x0401D211 RID: 119313
		[Nullable(2)]
		protected VisionDetailDesc CurrentData;

		// Token: 0x0401D212 RID: 119314
		[Nullable(2)]
		private VisionFetterSuitItem VisionFetterSuitItem;

		// Token: 0x0401D213 RID: 119315
		[Nullable(2)]
		private VisionDetailDesc Data;
	}
}
