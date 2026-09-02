using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x02006617 RID: 26135
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballItemWeaponGridView : PinballItemGridView<PinballWeaponData>
	{
		// Token: 0x06041507 RID: 267527 RVA: 0x010C0E06 File Offset: 0x010BF006
		public void BindReduceButtonCallback(Func<IPinballItemButtonCallback, bool> callback)
		{
			this.ReduceButtonCallback = callback;
		}

		// Token: 0x06041508 RID: 267528 RVA: 0x010C0E0F File Offset: 0x010BF00F
		public void BindFocusListenerDelegate(Action<IPinballItemToggleCallback> callback)
		{
			this.FocusListenerCallback = callback;
		}

		// Token: 0x06041509 RID: 267529 RVA: 0x010C0E18 File Offset: 0x010BF018
		protected override void OnStart()
		{
			base.OnStart();
			base.GetItemToggle().bLockStateOnSelect = true;
		}

		// Token: 0x0604150A RID: 267530 RVA: 0x010C0E2C File Offset: 0x010BF02C
		public override UniTask RefreshAsync(PinballWeaponData data, bool isSelected, int gridIndex)
		{
			PinballItemWeaponGridView.<RefreshAsync>d__6 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<PinballItemWeaponGridView.<RefreshAsync>d__6>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604150B RID: 267531 RVA: 0x010C0E77 File Offset: 0x010BF077
		public override void Refresh(PinballWeaponData data, bool isSelected, int gridIndex)
		{
			this.RefreshAsync(data, isSelected, gridIndex).Forget();
		}

		// Token: 0x040248B2 RID: 149682
		[Nullable(2)]
		protected new PinballWeaponData Data;

		// Token: 0x040248B3 RID: 149683
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<IPinballItemButtonCallback, bool> ReduceButtonCallback;

		// Token: 0x040248B4 RID: 149684
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IPinballItemToggleCallback> FocusListenerCallback;
	}
}
