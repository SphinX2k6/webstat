using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.Views
{
	// Token: 0x0200576D RID: 22381
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class MenuScrollSettingBaseItem : UiPanelBase
	{
		// Token: 0x06038F3B RID: 233275 RVA: 0x00E6E165 File Offset: 0x00E6C365
		public void Initialize(UUIItem uiItem, Action<int> saveCallback, Action<string> sequence)
		{
			this.FireSaveMenuChange = saveCallback;
			this.PlaySequenceByName = sequence;
			this.SourceItem = uiItem;
		}

		// Token: 0x06038F3C RID: 233276 RVA: 0x00E6E17C File Offset: 0x00E6C37C
		public UniTask Init()
		{
			MenuScrollSettingBaseItem.<Init>d__5 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MenuScrollSettingBaseItem.<Init>d__5>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038F3D RID: 233277 RVA: 0x00E6E1BF File Offset: 0x00E6C3BF
		protected override void OnRegisterComponent()
		{
		}

		// Token: 0x06038F3E RID: 233278 RVA: 0x00E6E1C1 File Offset: 0x00E6C3C1
		protected override void OnStart()
		{
		}

		// Token: 0x06038F3F RID: 233279 RVA: 0x00E6E1C3 File Offset: 0x00E6C3C3
		protected override void OnBeforeDestroy()
		{
			this.Clear();
		}

		// Token: 0x06038F40 RID: 233280 RVA: 0x00E6E1CB File Offset: 0x00E6C3CB
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x06038F41 RID: 233281 RVA: 0x00E6E1D4 File Offset: 0x00E6C3D4
		public void Clear()
		{
			this.OnClear();
		}

		// Token: 0x06038F42 RID: 233282 RVA: 0x00E6E1DC File Offset: 0x00E6C3DC
		protected virtual void OnClear()
		{
		}

		// Token: 0x06038F43 RID: 233283 RVA: 0x00E6E1DE File Offset: 0x00E6C3DE
		public virtual UniTask ClearAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06038F44 RID: 233284 RVA: 0x00E6E1E5 File Offset: 0x00E6C3E5
		protected virtual void OnRemoveEvents()
		{
		}

		// Token: 0x06038F45 RID: 233285 RVA: 0x00E6E1E7 File Offset: 0x00E6C3E7
		public virtual void PlaySequenceFromName(string name)
		{
		}

		// Token: 0x06038F46 RID: 233286 RVA: 0x00E6E1EC File Offset: 0x00E6C3EC
		protected bool GetItemClickLimit(UUISelectableComponent component)
		{
			if (component.GetSelfInteractive())
			{
				return false;
			}
			MenuData data = this.Data;
			if (data != null && data.BtnDisableTipsEnable)
			{
				return true;
			}
			if (this.Data != null && !string.IsNullOrEmpty(this.Data.BtnDisableTips))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(this.Data.BtnDisableTips, Array.Empty<object>());
			}
			else
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotModify", Array.Empty<object>());
			}
			return true;
		}

		// Token: 0x06038F47 RID: 233287
		public abstract void SetInteractionActive(bool val);

		// Token: 0x06038F48 RID: 233288 RVA: 0x00E6E264 File Offset: 0x00E6C464
		public void ExecuteUpdate(MenuData data, bool bGameSettingsUpdate)
		{
			this.Data = data;
			this.Update(data, bGameSettingsUpdate);
			this.SetDetailVisible(data.GetIsDetailTextVisible());
		}

		// Token: 0x06038F49 RID: 233289
		public abstract void Update(MenuData data, bool bGameSettingsUpdate);

		// Token: 0x06038F4A RID: 233290 RVA: 0x00E6E281 File Offset: 0x00E6C481
		public void SetDetailVisible(bool bVisible)
		{
			if (this.Data == null)
			{
				return;
			}
			if (bVisible && !this.Data.HasDetailText())
			{
				return;
			}
			this.Data.SetDetailTextVisible(bVisible);
			this.OnSetDetailVisible(bVisible);
		}

		// Token: 0x06038F4B RID: 233291 RVA: 0x00E6E2B0 File Offset: 0x00E6C4B0
		protected virtual void OnSetDetailVisible(bool bVisible)
		{
		}

		// Token: 0x06038F4C RID: 233292 RVA: 0x00E6E2B4 File Offset: 0x00E6C4B4
		protected UniTask SetToggleSprite(string spritePath, string lockSpritePath, int name, int spriteName)
		{
			MenuScrollSettingBaseItem.<SetToggleSprite>d__21 <SetToggleSprite>d__;
			<SetToggleSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetToggleSprite>d__.<>4__this = this;
			<SetToggleSprite>d__.spritePath = spritePath;
			<SetToggleSprite>d__.lockSpritePath = lockSpritePath;
			<SetToggleSprite>d__.name = name;
			<SetToggleSprite>d__.spriteName = spriteName;
			<SetToggleSprite>d__.<>1__state = -1;
			<SetToggleSprite>d__.<>t__builder.Start<MenuScrollSettingBaseItem.<SetToggleSprite>d__21>(ref <SetToggleSprite>d__);
			return <SetToggleSprite>d__.<>t__builder.Task;
		}

		// Token: 0x040206E2 RID: 132834
		[Nullable(2)]
		protected MenuData Data;

		// Token: 0x040206E3 RID: 132835
		protected Action<int> FireSaveMenuChange = delegate(int val)
		{
		};

		// Token: 0x040206E4 RID: 132836
		protected Action<string> PlaySequenceByName = delegate(string name)
		{
		};

		// Token: 0x040206E5 RID: 132837
		[Nullable(2)]
		private UUIItem SourceItem;
	}
}
