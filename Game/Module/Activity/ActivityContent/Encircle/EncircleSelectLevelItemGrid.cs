using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200687D RID: 26749
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EncircleSelectLevelItemGrid : GridProxyAbstract<IEncircleSelectLevelData>
	{
		// Token: 0x06042A7E RID: 273022 RVA: 0x0111C0B4 File Offset: 0x0111A2B4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIArtText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickedSelectButton))
			};
		}

		// Token: 0x06042A7F RID: 273023 RVA: 0x0111C1FC File Offset: 0x0111A3FC
		private void InitTickSystem()
		{
			this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.RefreshTimeTick), "EncircleSelectLevelItemGrid", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Pause(this.TickId);
			}
		}

		// Token: 0x06042A80 RID: 273024 RVA: 0x0111C24D File Offset: 0x0111A44D
		protected override void OnStart()
		{
			this.InitTickSystem();
			this.AddEventListener();
		}

		// Token: 0x06042A81 RID: 273025 RVA: 0x0111C25B File Offset: 0x0111A45B
		protected void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EncircleChallengePb>(EEventName.EncircleDataUpdate, new Action<EncircleChallengePb>(this.OnEncircleDataUpdate));
		}

		// Token: 0x06042A82 RID: 273026 RVA: 0x0111C279 File Offset: 0x0111A479
		protected void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.EncircleDataUpdate, new Action<EncircleChallengePb>(this.OnEncircleDataUpdate));
		}

		// Token: 0x06042A83 RID: 273027 RVA: 0x0111C297 File Offset: 0x0111A497
		protected override void OnBeforeShow()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Resume(this.TickId);
			}
		}

		// Token: 0x06042A84 RID: 273028 RVA: 0x0111C2B3 File Offset: 0x0111A4B3
		public void RefreshView(IEncircleSelectLevelData data)
		{
			this.LevelData = data;
			this.EncircleConfigData = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleGroup(this.LevelData.GroupId);
			this.RefreshOpen();
			this.RefreshDesc();
			this.RefreshComplete();
			this.RefreshRedPoint();
		}

		// Token: 0x06042A85 RID: 273029 RVA: 0x0111C2F0 File Offset: 0x0111A4F0
		private void RefreshOpen()
		{
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			if (encircleData == null)
			{
				return;
			}
			this.IsOpen = encircleData.CheckChallengeIsOpen(this.EncircleConfigData.Value.Challenges(0));
			this.IsPrevComplete = encircleData.CheckPreChallengeComplete(this.EncircleConfigData.Value.Challenges(0));
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(this.IsOpen && this.IsPrevComplete);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(!this.IsOpen || !this.IsPrevComplete);
			}
			UUIItem item3 = base.GetItem(5);
			if (item3 != null)
			{
				item3.SetUIActive(!this.IsOpen);
			}
			UUISprite sprite = base.GetSprite(11);
			if (sprite != null)
			{
				sprite.SetUIActive(this.IsOpen);
			}
			if (!this.IsOpen)
			{
				UUIText text = base.GetText(6);
				if (text != null)
				{
					text.SetText(encircleData.GetUnlockDesc(this.EncircleConfigData.Value.Challenges(0)), true);
				}
			}
			if (!this.IsOpen || !this.IsPrevComplete)
			{
				UUIText text2 = base.GetText(4);
				if (text2 != null)
				{
					text2.SetColor(FColor.FromHex("C2D1DD"));
				}
				UUISprite sprite2 = base.GetSprite(11);
				if (sprite2 == null)
				{
					return;
				}
				sprite2.SetColor(FColor.FromHex("C2D1DD"));
				return;
			}
			else
			{
				UUIText text3 = base.GetText(4);
				if (text3 != null)
				{
					text3.SetColor(FColor.FromHex("FFFFFF"));
				}
				UUISprite sprite3 = base.GetSprite(11);
				if (sprite3 == null)
				{
					return;
				}
				sprite3.SetColor(FColor.FromHex("FFFFFF"));
				return;
			}
		}

		// Token: 0x06042A86 RID: 273030 RVA: 0x0111C480 File Offset: 0x0111A680
		private void RefreshRedPoint()
		{
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			if (encircleData == null)
			{
				return;
			}
			bool uiactive = encircleData.CheckGroupRedPointShow(this.EncircleConfigData.Value.Id);
			UUIItem item = base.GetItem(10);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x06042A87 RID: 273031 RVA: 0x0111C4CC File Offset: 0x0111A6CC
		private void RefreshDesc()
		{
			UUIArtText artText = base.GetArtText(3);
			if (artText != null)
			{
				artText.SetText((this.Index + 1).ToString());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.EncircleConfigData.Value.LevelTitle, Array.Empty<object>());
		}

		// Token: 0x06042A88 RID: 273032 RVA: 0x0111C524 File Offset: 0x0111A724
		private void RefreshComplete()
		{
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			if (encircleData == null)
			{
				return;
			}
			bool uiactive = encircleData.CheckChallengeComplete(this.EncircleConfigData.Value.Challenges(0));
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			bool uiactive2 = encircleData.CheckChallengeComplete(this.EncircleConfigData.Value.Challenges(1));
			UUIItem item2 = base.GetItem(8);
			if (item2 != null)
			{
				item2.SetUIActive(uiactive2);
			}
			UUIItem item3 = base.GetItem(9);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(uiactive2);
		}

		// Token: 0x06042A89 RID: 273033 RVA: 0x0111C5AF File Offset: 0x0111A7AF
		public void SetIndex(int index)
		{
			this.Index = index;
		}

		// Token: 0x06042A8A RID: 273034 RVA: 0x0111C5B8 File Offset: 0x0111A7B8
		private void OnEncircleDataUpdate(EncircleChallengePb newData)
		{
			if (this.LevelData == null)
			{
				return;
			}
			this.RefreshView(this.LevelData);
		}

		// Token: 0x06042A8B RID: 273035 RVA: 0x0111C5D0 File Offset: 0x0111A7D0
		private void OnClickedSelectButton()
		{
			if (!this.IsOpen)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Encirle_LevelLockTips_Text", Array.Empty<object>());
				return;
			}
			if (this.IsPrevComplete)
			{
				DetailArgs param = new DetailArgs
				{
					GroupId = this.LevelData.GroupId
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.EncircleLevelDetailView, param, null);
				return;
			}
			EncircleChallenge? encircleChallengeConfig = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallengeConfig(this.EncircleConfigData.Value.Challenges(0));
			EncircleChallenge? encircleChallengeConfig2 = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallengeConfig(encircleChallengeConfig.Value.PreId);
			if (encircleChallengeConfig2 == null)
			{
				return;
			}
			string levelTitle = encircleChallengeConfig2.Value.LevelTitle;
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(levelTitle, levelTitle);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Encirle_DifficultyLockTips_Text", new object[]
			{
				multiTextByKey
			});
		}

		// Token: 0x06042A8C RID: 273036 RVA: 0x0111C6A9 File Offset: 0x0111A8A9
		protected override void OnAfterHide()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Pause(this.TickId);
			}
		}

		// Token: 0x06042A8D RID: 273037 RVA: 0x0111C6C5 File Offset: 0x0111A8C5
		protected override void OnBeforeDestroy()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
			this.RemoveEventListener();
		}

		// Token: 0x06042A8E RID: 273038 RVA: 0x0111C6EE File Offset: 0x0111A8EE
		public void RefreshTimeTick(float deltaTime)
		{
			this.RefreshOpen();
		}

		// Token: 0x040251B1 RID: 151985
		private const string NORMAL_COLOR = "FFFFFF";

		// Token: 0x040251B2 RID: 151986
		private const string LOCK_COLOR = "C2D1DD";

		// Token: 0x040251B3 RID: 151987
		[Nullable(2)]
		private IEncircleSelectLevelData LevelData;

		// Token: 0x040251B4 RID: 151988
		private int Index;

		// Token: 0x040251B5 RID: 151989
		private bool IsOpen;

		// Token: 0x040251B6 RID: 151990
		private bool IsPrevComplete;

		// Token: 0x040251B7 RID: 151991
		private int TickId = -1;

		// Token: 0x040251B8 RID: 151992
		private EncircleChallengeGroup? EncircleConfigData;
	}
}
