using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

namespace CSharpScript.Game.Module.SurvivorsRogue.RogueFlow.View
{
	// Token: 0x02004EF4 RID: 20212
	[NullableContext(1)]
	[Nullable(0)]
	public class SurvivorsRogueEvolveView : UiViewBase, ISurvivorsRogueCommandView
	{
		// Token: 0x060343B7 RID: 213943 RVA: 0x00D1058F File Offset: 0x00D0E78F
		public SurvivorsRogueEvolveView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x17008A02 RID: 35330
		// (get) Token: 0x060343B8 RID: 213944 RVA: 0x00D105AA File Offset: 0x00D0E7AA
		int ISurvivorsRogueCommandView.CommandIncId
		{
			get
			{
				return this.CommandIncId;
			}
		}

		// Token: 0x17008A03 RID: 35331
		// (get) Token: 0x060343B9 RID: 213945 RVA: 0x00D105B2 File Offset: 0x00D0E7B2
		SurvivorsRogueCommandBase ISurvivorsRogueCommandView.Command
		{
			get
			{
				return this.Command;
			}
		}

		// Token: 0x060343BA RID: 213946 RVA: 0x00D105BC File Offset: 0x00D0E7BC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnClose))
			};
		}

		// Token: 0x060343BB RID: 213947 RVA: 0x00D106A7 File Offset: 0x00D0E8A7
		public void CloseView()
		{
			base.CloseMe(null);
		}

		// Token: 0x060343BC RID: 213948 RVA: 0x00D106B0 File Offset: 0x00D0E8B0
		private void OnClickBtnClose()
		{
			this.EndEvolveFlow().ContinueWith(delegate()
			{
				this.CurrentViewInfoIndex++;
				if (this.CurrentViewInfoIndex >= this.ViewInfoList.Count)
				{
					this.UiViewSequence.CloseSequenceName = (this.ViewAnimVisibleState ? "Close" : "Close01");
					this.Command.Execute();
					return;
				}
				this.RefreshNextView(true, true);
			});
		}

		// Token: 0x060343BD RID: 213949 RVA: 0x00D106CC File Offset: 0x00D0E8CC
		private UniTask EndEvolveFlow()
		{
			SurvivorsRogueEvolveView.<EndEvolveFlow>d__16 <EndEvolveFlow>d__;
			<EndEvolveFlow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EndEvolveFlow>d__.<>4__this = this;
			<EndEvolveFlow>d__.<>1__state = -1;
			<EndEvolveFlow>d__.<>t__builder.Start<SurvivorsRogueEvolveView.<EndEvolveFlow>d__16>(ref <EndEvolveFlow>d__);
			return <EndEvolveFlow>d__.<>t__builder.Task;
		}

		// Token: 0x060343BE RID: 213950 RVA: 0x00D10710 File Offset: 0x00D0E910
		protected override UniTask OnBeforeStartAsync()
		{
			SurvivorsRogueEvolveView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueEvolveView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060343BF RID: 213951 RVA: 0x00D10754 File Offset: 0x00D0E954
		private void GetViewInfo()
		{
			List<SurvivorsEvolveViewInfo> viewInfoList = this.Command.GetViewInfoList();
			this.ViewInfoList = viewInfoList;
			this.CurrentViewInfoIndex = 0;
		}

		// Token: 0x060343C0 RID: 213952 RVA: 0x00D1077B File Offset: 0x00D0E97B
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x060343C1 RID: 213953 RVA: 0x00D1077D File Offset: 0x00D0E97D
		protected override void OnAfterShow()
		{
		}

		// Token: 0x060343C2 RID: 213954 RVA: 0x00D1077F File Offset: 0x00D0E97F
		protected override void OnBeforeDestroy()
		{
			this.RootActor.OnSequencePlayEvent.Unbind();
			SurvivorsRogueCommandEvolve command = this.Command;
			if (command == null)
			{
				return;
			}
			command.BindView(null);
		}

		// Token: 0x060343C3 RID: 213955 RVA: 0x00D107A4 File Offset: 0x00D0E9A4
		private void OnEventSequence(string sequenceName, string eventName)
		{
			if (sequenceName == "LevelUp" && eventName == "LevelUp")
			{
				SurvivorsEvolveViewInfo survivorsEvolveViewInfo = (this.CurrentViewInfoIndex < this.ViewInfoList.Count) ? this.ViewInfoList[this.CurrentViewInfoIndex] : null;
				if (survivorsEvolveViewInfo == null || !survivorsEvolveViewInfo.PlayTween.GetValueOrDefault())
				{
					return;
				}
				int sourceId = survivorsEvolveViewInfo.SourceId;
				int evolveQualityId = this.GetEvolveQualityId(survivorsEvolveViewInfo.WeaponEvolveIds);
				SurvivorsRogueWeaponStateGrid weaponGrid = this.RoleStatePanel.GetWeaponGrid(sourceId);
				if (weaponGrid != null)
				{
					weaponGrid.SetQualityById(evolveQualityId);
					weaponGrid.SetLevelUp();
				}
			}
		}

		// Token: 0x060343C4 RID: 213956 RVA: 0x00D10839 File Offset: 0x00D0EA39
		public void Refresh()
		{
			this.GetViewInfo();
			this.RefreshWeaponQuality();
			this.RefreshNextView(false, true);
		}

		// Token: 0x060343C5 RID: 213957 RVA: 0x00D10850 File Offset: 0x00D0EA50
		private void RefreshNextView(bool playSwitch, bool refreshContent)
		{
			SurvivorsRogueEvolveView.<>c__DisplayClass24_0 CS$<>8__locals1 = new SurvivorsRogueEvolveView.<>c__DisplayClass24_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.refreshContent = refreshContent;
			CS$<>8__locals1.playSwitch = playSwitch;
			UiAsyncTask task = new UiAsyncTask("SurvivorsRogueEvolveView.Refresh", delegate()
			{
				SurvivorsRogueEvolveView.<>c__DisplayClass24_0.<<RefreshNextView>b__0>d <<RefreshNextView>b__0>d;
				<<RefreshNextView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshNextView>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshNextView>b__0>d.<>1__state = -1;
				<<RefreshNextView>b__0>d.<>t__builder.Start<SurvivorsRogueEvolveView.<>c__DisplayClass24_0.<<RefreshNextView>b__0>d>(ref <<RefreshNextView>b__0>d);
				return <<RefreshNextView>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x060343C6 RID: 213958 RVA: 0x00D10898 File Offset: 0x00D0EA98
		private UniTask RefreshAsync()
		{
			SurvivorsRogueEvolveView.<RefreshAsync>d__25 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<SurvivorsRogueEvolveView.<RefreshAsync>d__25>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060343C7 RID: 213959 RVA: 0x00D108DC File Offset: 0x00D0EADC
		private void PlayTween(int weaponId)
		{
			SurvivorsWeapon? survivorsWeapon = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(weaponId);
			UUITexture texture = base.GetTexture(6);
			base.SetTextureShowUntilLoaded(survivorsWeapon.Value.Icon, texture, null);
			TArray<UActorComponent> tarray = texture.GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				ULGUIPlayTweenComponent ulguiplayTweenComponent = tarray.Get(i) as ULGUIPlayTweenComponent;
				if (ulguiplayTweenComponent != null)
				{
					ULGUIPlayTween_Vector3 ulguiplayTween_Vector = ulguiplayTweenComponent.GetPlayTween() as ULGUIPlayTween_Vector3;
					UUIItem textureIconItem = this.CardItem.GetTextureIconItem();
					UUIItem rootItem = this.RoleStatePanel.GetWeaponGrid(weaponId).GetRootItem();
					ulguiplayTween_Vector.from = global::Vector.Create(textureIconItem.GetLGUISpaceAbsolutePosition()).ToUeVectorOld();
					ulguiplayTween_Vector.to = global::Vector.Create(rootItem.GetLGUISpaceAbsolutePosition()).ToUeVectorOld();
					ulguiplayTweenComponent.Stop();
					ulguiplayTweenComponent.Play();
				}
			}
		}

		// Token: 0x060343C8 RID: 213960 RVA: 0x00D109CC File Offset: 0x00D0EBCC
		private void RefreshWeaponQuality()
		{
			foreach (SurvivorsEvolveViewInfo survivorsEvolveViewInfo in this.ViewInfoList)
			{
				if (survivorsEvolveViewInfo.WeaponEvolveIds != null)
				{
					int sourceId = survivorsEvolveViewInfo.SourceId;
					SurvivorsWeaponGainData weaponDataByWeaponId = ModelBase<SurvivorsRogueModel>.Instance.GainData.GetWeaponDataByWeaponId(sourceId);
					if (weaponDataByWeaponId != null)
					{
						RepeatedField<int> evolves = weaponDataByWeaponId.Data.Evolves;
						List<int> list = new List<int>();
						foreach (int num in evolves)
						{
							bool flag = false;
							foreach (int num2 in survivorsEvolveViewInfo.WeaponEvolveIds)
							{
								if (num == num2)
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								list.Add(num);
							}
						}
						int evolveQualityId = this.GetEvolveQualityId(list.ToArray());
						SurvivorsRogueWeaponStateGrid weaponGrid = this.RoleStatePanel.GetWeaponGrid(sourceId);
						if (weaponGrid != null)
						{
							weaponGrid.SetQualityById(evolveQualityId);
						}
					}
				}
			}
		}

		// Token: 0x060343C9 RID: 213961 RVA: 0x00D10AF4 File Offset: 0x00D0ECF4
		private int GetEvolveQualityId(int[] evolveIds)
		{
			int num = 0;
			foreach (int evolveId in evolveIds)
			{
				num = Math.Max(num, ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeaponEvolve(evolveId).Value.Quality);
			}
			return num;
		}

		// Token: 0x0401E242 RID: 123458
		public int CommandIncId;

		// Token: 0x0401E243 RID: 123459
		public SurvivorsRogueCommandEvolve Command;

		// Token: 0x0401E244 RID: 123460
		[Nullable(2)]
		private SurvivorsRogueCardBase CardItem;

		// Token: 0x0401E245 RID: 123461
		[Nullable(2)]
		private SurvivorsRogueRoleStatePanel RoleStatePanel;

		// Token: 0x0401E246 RID: 123462
		private List<SurvivorsEvolveViewInfo> ViewInfoList = new List<SurvivorsEvolveViewInfo>();

		// Token: 0x0401E247 RID: 123463
		private int CurrentViewInfoIndex;

		// Token: 0x0401E248 RID: 123464
		private bool IsSpecialEvolve;

		// Token: 0x0401E249 RID: 123465
		private bool ViewAnimVisibleState = true;
	}
}
