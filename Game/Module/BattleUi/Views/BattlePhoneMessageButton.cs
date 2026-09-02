using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhoneMessage.View;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FBF RID: 24511
	public class BattlePhoneMessageButton : BattleEntranceButton, IPhoneMessageButtonImplement
	{
		// Token: 0x0603DA28 RID: 252456 RVA: 0x00FB4200 File Offset: 0x00FB2400
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUISprite)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUITexture)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUITexture)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUINiagara)));
		}

		// Token: 0x0603DA29 RID: 252457 RVA: 0x00FB42B8 File Offset: 0x00FB24B8
		protected override void OnStart()
		{
			base.OnStart();
			this.Helper = new PhoneMessageButtonHelper(this.RootItem, this.RootActor, base.GetItem(1), base.GetSprite(2), base.GetItem(4), base.GetTexture(5), base.GetItem(6), base.GetUiNiagara(7), delegate(string path, UUITexture texture)
			{
				base.SetTextureByPath(path, texture, null, null);
			});
			this.Helper.Init();
		}

		// Token: 0x0603DA2A RID: 252458 RVA: 0x00FB4323 File Offset: 0x00FB2523
		protected override void OnShowBattleChildView()
		{
			base.OnShowBattleChildView();
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.OnShowBattleChildView();
		}

		// Token: 0x0603DA2B RID: 252459 RVA: 0x00FB433B File Offset: 0x00FB253B
		protected override void OnHideBattleChildView()
		{
			base.OnHideBattleChildView();
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.OnHideBattleChildView();
		}

		// Token: 0x0603DA2C RID: 252460 RVA: 0x00FB4353 File Offset: 0x00FB2553
		public override void Reset()
		{
			base.Reset();
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.Clear();
		}

		// Token: 0x0603DA2D RID: 252461 RVA: 0x00FB436B File Offset: 0x00FB256B
		public void CheckAndPlayPhoneSequence()
		{
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.CheckAndPlayPhoneSequence();
		}

		// Token: 0x0603DA2E RID: 252462 RVA: 0x00FB437D File Offset: 0x00FB257D
		public void PopShowHeadIcon()
		{
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.PopShowHeadIcon();
		}

		// Token: 0x0603DA2F RID: 252463 RVA: 0x00FB438F File Offset: 0x00FB258F
		public void HideHeadIcon()
		{
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.HideHeadIcon();
		}

		// Token: 0x04022992 RID: 141714
		[Nullable(2)]
		private PhoneMessageButtonHelper Helper;

		// Token: 0x0200C029 RID: 49193
		private enum EChildType
		{
			// Token: 0x0403B27F RID: 242303
			Button,
			// Token: 0x0403B280 RID: 242304
			RedDotItem,
			// Token: 0x0403B281 RID: 242305
			SpriteEnterIcon,
			// Token: 0x0403B282 RID: 242306
			TexPhoneBlue,
			// Token: 0x0403B283 RID: 242307
			PanelPrefabHead,
			// Token: 0x0403B284 RID: 242308
			TexIconHead,
			// Token: 0x0403B285 RID: 242309
			BubbleItem,
			// Token: 0x0403B286 RID: 242310
			NiagaraItem
		}
	}
}
