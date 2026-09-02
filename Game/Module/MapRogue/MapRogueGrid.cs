using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200596E RID: 22894
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueGrid : UiPanelBase
	{
		// Token: 0x0603A02A RID: 237610 RVA: 0x00EAE080 File Offset: 0x00EAC280
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
		}

		// Token: 0x0603A02B RID: 237611 RVA: 0x00EAE134 File Offset: 0x00EAC334
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			extendToggle.OnPointDownCallBack.Unbind();
			extendToggle.OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnPointerDown));
			extendToggle.OnPointUpCallBack.Unbind();
			extendToggle.OnPointUpCallBack.Bind(new Action<EToggleState>(this.OnPointerUp));
			extendToggle.OnStateChange.Clear();
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.ExtendToggleStateChanged));
			extendToggle.CanExecuteChange.Unbind();
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
			extendToggle.OnHover.Clear();
			extendToggle.OnHover.Add(new Action(this.OnHover));
			extendToggle.OnUnHover.Clear();
			extendToggle.OnUnHover.Add(new Action(this.OnUnHover));
		}

		// Token: 0x0603A02C RID: 237612 RVA: 0x00EAE213 File Offset: 0x00EAC413
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0603A02D RID: 237613 RVA: 0x00EAE218 File Offset: 0x00EAC418
		private void OnPointerDown(EToggleState state)
		{
			foreach (ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase> valueTuple in this.SelectPanel)
			{
				valueTuple.Item1.PlaySequence("Pre", false);
				valueTuple.Item2.PlaySequence("Pre", false);
			}
			Action<EToggleState, MapGridData> onExtendTogglePointerDown = this.OnExtendTogglePointerDown;
			if (onExtendTogglePointerDown == null)
			{
				return;
			}
			onExtendTogglePointerDown(state, this.Data);
		}

		// Token: 0x0603A02E RID: 237614 RVA: 0x00EAE29C File Offset: 0x00EAC49C
		private void OnPointerUp(EToggleState state)
		{
			foreach (ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase> valueTuple in this.SelectPanel)
			{
				valueTuple.Item1.PlaySequence("PreUp", false);
				valueTuple.Item2.PlaySequence("PreUp", false);
			}
		}

		// Token: 0x0603A02F RID: 237615 RVA: 0x00EAE308 File Offset: 0x00EAC508
		private void ExtendToggleStateChanged(EToggleState state)
		{
			string seqDefine = (state == EToggleState.ETT_Checked) ? "Sle" : "UnSle";
			foreach (ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase> valueTuple in this.SelectPanel)
			{
				valueTuple.Item1.PlaySequence(seqDefine, true);
				valueTuple.Item2.PlaySequence(seqDefine, true);
			}
			Action<EToggleState, MapGridData> onExtendToggleStateChanged = this.OnExtendToggleStateChanged;
			if (onExtendToggleStateChanged == null)
			{
				return;
			}
			onExtendToggleStateChanged(state, this.Data);
		}

		// Token: 0x0603A030 RID: 237616 RVA: 0x00EAE398 File Offset: 0x00EAC598
		private bool CanExecuteChange()
		{
			return this.OnCanExecuteChangeFunc == null || this.OnCanExecuteChangeFunc(base.GetExtendToggle(0).GetToggleState(), this.Data);
		}

		// Token: 0x0603A031 RID: 237617 RVA: 0x00EAE3C4 File Offset: 0x00EAC5C4
		private void OnHover()
		{
			Action<MapGridData> onHoverFunc = this.OnHoverFunc;
			if (onHoverFunc != null)
			{
				onHoverFunc(this.Data);
			}
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			foreach (ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase> valueTuple in this.SelectPanel)
			{
				valueTuple.Item1.PlaySequence("Float", false);
				valueTuple.Item2.PlaySequence("Float", false);
			}
		}

		// Token: 0x0603A032 RID: 237618 RVA: 0x00EAE454 File Offset: 0x00EAC654
		private void OnUnHover()
		{
			foreach (ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase> valueTuple in this.SelectPanel)
			{
				valueTuple.Item1.PlaySequence("Move", false);
				valueTuple.Item2.PlaySequence("Move", false);
			}
			Action<MapGridData> onUnHoverFunc = this.OnUnHoverFunc;
			if (onUnHoverFunc == null)
			{
				return;
			}
			onUnHoverFunc(this.Data);
		}

		// Token: 0x0603A033 RID: 237619 RVA: 0x00EAE4D8 File Offset: 0x00EAC6D8
		public void SetGridToggleState(bool bSelectOn, bool bFireEvent = false)
		{
			if (!this.Data.Walkable)
			{
				return;
			}
			bool flag = base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked;
			EToggleState state = bSelectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleStateForce(state, bFireEvent, false, false);
			if (flag == bSelectOn)
			{
				return;
			}
			string seqDefine = bSelectOn ? "Sle" : "UnSle";
			foreach (ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase> valueTuple in this.SelectPanel)
			{
				valueTuple.Item1.PlaySequence(seqDefine, true);
				valueTuple.Item2.PlaySequence(seqDefine, true);
			}
		}

		// Token: 0x0603A034 RID: 237620 RVA: 0x00EAE588 File Offset: 0x00EAC788
		public void SetToggleMoveEnable(bool bEnable)
		{
			if (!this.Data.Walkable)
			{
				return;
			}
			this.WalkEnable = bEnable;
			foreach (ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase> valueTuple in this.SelectPanel)
			{
				valueTuple.Item1.SetState(bEnable);
				valueTuple.Item2.SetState(bEnable);
			}
		}

		// Token: 0x0603A035 RID: 237621 RVA: 0x00EAE600 File Offset: 0x00EAC800
		public void SetSelectPanel(MapRogueGridSelectBase back, MapRogueGridSelectBase front)
		{
			back.GetRootItem().SetUIParent(this.GetPanelSelectBack(), false);
			front.GetRootItem().SetUIParent(this.GetPanelSelectFront(), false);
			back.ResetAllSequence();
			front.ResetAllSequence();
			this.SelectPanel.Add(new ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase>(back, front));
			bool selected = base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked;
			foreach (ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase> valueTuple in this.SelectPanel)
			{
				valueTuple.Item1.SetSelected(selected);
				valueTuple.Item2.SetSelected(selected);
				valueTuple.Item1.SetState(this.WalkEnable);
				valueTuple.Item2.SetState(this.WalkEnable);
			}
			back.SetUiActive(true);
			front.SetUiActive(true);
		}

		// Token: 0x0603A036 RID: 237622 RVA: 0x00EAE6E4 File Offset: 0x00EAC8E4
		public void ClearSelectPanel()
		{
			this.SelectPanel.Clear();
		}

		// Token: 0x0603A037 RID: 237623 RVA: 0x00EAE6F1 File Offset: 0x00EAC8F1
		public UUIItem GetPanelEvent()
		{
			return base.GetItem(3);
		}

		// Token: 0x0603A038 RID: 237624 RVA: 0x00EAE6FA File Offset: 0x00EAC8FA
		public UUIItem GetPanelSelectFront()
		{
			return base.GetItem(5);
		}

		// Token: 0x0603A039 RID: 237625 RVA: 0x00EAE703 File Offset: 0x00EAC903
		public UUIItem GetPanelSelectBack()
		{
			return base.GetItem(4);
		}

		// Token: 0x0603A03A RID: 237626 RVA: 0x00EAE70C File Offset: 0x00EAC90C
		public void Refresh(MapGridData data)
		{
			this.Data = data;
			RogueResGridMapType? gridMapTypeConfigById = ConfigBase<MapRogueConfig>.Instance.GetGridMapTypeConfigById(this.Data.GridTypeId);
			if (gridMapTypeConfigById == null)
			{
				return;
			}
			List<string> list = new List<string>(gridMapTypeConfigById.Value.GroundPath().Keys);
			UUISprite sprite = base.GetSprite(1);
			sprite.SetUIActive(false);
			this.SetSpriteByPath(list[data.GroundPathIndex], sprite, true, null, delegate(bool _)
			{
				sprite.SetUIActive(true);
			});
			bool flag = gridMapTypeConfigById.Value.ExtraPathListLength > 0;
			bool flag2 = this.Data.ExtraPathIndex >= 0;
			this.HasDecoration = (flag || flag2);
			UUIItem item = base.GetItem(6);
			UUISprite spriteExtra = base.GetSprite(2);
			item.SetAlpha(1f);
			item.SetUIActive(this.HasDecoration && this.Data.HasVision);
			float anchorOffsetY = spriteExtra.GetAnchorOffsetY();
			spriteExtra.SetUIActive(false);
			if (flag2)
			{
				List<string> list2 = new List<string>(gridMapTypeConfigById.Value.DecorationPath().Keys);
				this.SetSpriteByPath(list2[data.ExtraPathIndex], spriteExtra, true, null, delegate(bool _)
				{
					spriteExtra.SetUIActive(true);
				});
			}
			TArray<UUIItem> attachUIChildren = item.GetAttachUIChildren();
			attachUIChildren.RemoveAt(0);
			int num = attachUIChildren.Num();
			int num2 = Math.Max(num, gridMapTypeConfigById.Value.ExtraPathListLength);
			for (int i = 0; i < num2; i++)
			{
				if (i >= gridMapTypeConfigById.Value.ExtraPathListLength)
				{
					attachUIChildren.Get(i).SetUIActive(false);
				}
				else
				{
					UUISprite uuisprite;
					if (i < num)
					{
						uuisprite = (attachUIChildren.Get(i) as UUISprite);
					}
					else
					{
						uuisprite = (Singleton<LguiUtil>.Instance.CopyItem(spriteExtra, item) as UUISprite);
					}
					int num3 = (i < gridMapTypeConfigById.Value.ExtraOffsetListLength) ? gridMapTypeConfigById.Value.ExtraOffsetList(i) : 0;
					uuisprite.SetAnchorOffsetY(anchorOffsetY + (float)num3);
					uuisprite.SetUIActive(false);
					UUISprite capturedCopyDecoration = uuisprite;
					this.SetSpriteByPath(gridMapTypeConfigById.Value.ExtraPathList(i), capturedCopyDecoration, true, null, delegate(bool _)
					{
						capturedCopyDecoration.SetUIActive(true);
					});
				}
			}
			this.WalkEnable = this.Data.Walkable;
			bool selected = base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked;
			foreach (ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase> valueTuple in this.SelectPanel)
			{
				valueTuple.Item1.SetSelected(selected);
				valueTuple.Item2.SetSelected(selected);
				valueTuple.Item1.SetState(this.WalkEnable);
				valueTuple.Item2.SetState(this.WalkEnable);
			}
			this.SetActive(true);
		}

		// Token: 0x0603A03B RID: 237627 RVA: 0x00EAEA54 File Offset: 0x00EACC54
		public void SetVision(bool bHasVision)
		{
			if (this.HasDecoration)
			{
				base.GetItem(6).SetUIActive(bHasVision);
			}
		}

		// Token: 0x0603A03C RID: 237628 RVA: 0x00EAEA6C File Offset: 0x00EACC6C
		public void SetPerspectiveMode(bool bOn)
		{
			if (!this.HasDecoration)
			{
				return;
			}
			this.PerspectiveModeCount = Math.Max(0, this.PerspectiveModeCount + (bOn ? 1 : -1));
			bool flag = this.PerspectiveModeCount > 0;
			if (this.IsInPerspectiveMode == flag)
			{
				return;
			}
			this.IsInPerspectiveMode = bOn;
			int num = (!bOn) ? 1 : 0;
			TArray<UActorComponent> tarray = base.GetItem(6).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			int num2 = tarray.Num();
			for (int i = 0; i < num2; i++)
			{
				ULGUIPlayTweenComponent ulguiplayTweenComponent = tarray.Get(i) as ULGUIPlayTweenComponent;
				ulguiplayTweenComponent.Stop();
				if (i == num)
				{
					ulguiplayTweenComponent.Play();
				}
			}
		}

		// Token: 0x04020E2D RID: 134701
		private MapGridData Data;

		// Token: 0x04020E2E RID: 134702
		private int PerspectiveModeCount;

		// Token: 0x04020E2F RID: 134703
		private bool IsInPerspectiveMode;

		// Token: 0x04020E30 RID: 134704
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<EToggleState, MapGridData> OnExtendTogglePointerDown;

		// Token: 0x04020E31 RID: 134705
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<EToggleState, MapGridData> OnExtendToggleStateChanged;

		// Token: 0x04020E32 RID: 134706
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<EToggleState, MapGridData, bool> OnCanExecuteChangeFunc;

		// Token: 0x04020E33 RID: 134707
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<MapGridData> OnHoverFunc;

		// Token: 0x04020E34 RID: 134708
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<MapGridData> OnUnHoverFunc;

		// Token: 0x04020E35 RID: 134709
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public List<ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase>> SelectPanel = new List<ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase>>();

		// Token: 0x04020E36 RID: 134710
		private bool WalkEnable = true;

		// Token: 0x04020E37 RID: 134711
		private bool HasDecoration;
	}
}
