using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005BA6 RID: 23462
	[NullableContext(2)]
	[Nullable(0)]
	public class InteractionLongPressButton : UiPanelBase
	{
		// Token: 0x0603B5AC RID: 243116 RVA: 0x00F0897C File Offset: 0x00F06B7C
		protected override void OnRegisterComponent()
		{
			this.IsMobile = Singleton<Info>.Instance.IsInTouch();
			if (this.IsMobile)
			{
				this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
				{
					new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
					new ValueTuple<int, Type>(1, typeof(UUITexture)),
					new ValueTuple<int, Type>(2, typeof(UUISprite)),
					new ValueTuple<int, Type>(3, typeof(UUIItem)),
					new ValueTuple<int, Type>(4, typeof(UUIText))
				};
				return;
			}
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText))
			};
		}

		// Token: 0x0603B5AD RID: 243117 RVA: 0x00F08AAC File Offset: 0x00F06CAC
		protected override UniTask OnBeforeStartAsync()
		{
			InteractionLongPressButton.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InteractionLongPressButton.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B5AE RID: 243118 RVA: 0x00F08AF0 File Offset: 0x00F06CF0
		protected unsafe override void OnStart()
		{
			if (this.IsMobile)
			{
				this.Button = base.GetButton(0);
				this.ProgressFill = base.GetTexture(1);
			}
			else
			{
				this.Button = base.GetButton(0);
				this.ProgressFill = base.GetTexture(1);
			}
			this.SequencePlayer = ((this.RootItem != null) ? new UiSequencePlayer(this.RootItem) : null);
			UUIButtonComponent button = this.Button;
			if (button != null)
			{
				button.SetSelfInteractive(true);
			}
			UUIButtonComponent button2 = this.Button;
			if (button2 != null)
			{
				button2.OnPointDownCallBack.Bind(new Action(this.OnButtonPointDown));
			}
			UUIButtonComponent button3 = this.Button;
			if (button3 != null)
			{
				button3.OnPointUpCallBack.Bind(new Action(this.OnButtonPointUp));
			}
			UUIButtonComponent button4 = this.Button;
			if (button4 != null)
			{
				button4.OnPointExitCallBack.Bind(new Action(this.OnButtonPointUp));
			}
			UUITexture progressFill = this.ProgressFill;
			if (progressFill != null)
			{
				progressFill.SetFillAmount(0f);
			}
			this.SetActive(false);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.WRY;
			string message = "[LongPressButton] OnStart";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ButtonResolved", this.Button != null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ProgressResolved", this.ProgressFill != null);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item = "Interactable";
			UUIButtonComponent button5 = this.Button;
			ptr = new ValueTuple<string, object>(item, button5 != null && button5.IsInteractable());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x0603B5AF RID: 243119 RVA: 0x00F08C8C File Offset: 0x00F06E8C
		protected override void OnBeforeDestroy()
		{
			UUIButtonComponent button = this.Button;
			if (button != null)
			{
				button.OnPointDownCallBack.Unbind();
			}
			UUIButtonComponent button2 = this.Button;
			if (button2 != null)
			{
				button2.OnPointUpCallBack.Unbind();
			}
			UUIButtonComponent button3 = this.Button;
			if (button3 != null)
			{
				button3.OnPointExitCallBack.Unbind();
			}
			this.Button = null;
			this.ProgressFill = null;
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			this.OnPressCallback = null;
			this.UnbindEntity();
			this.KeyItem = null;
		}

		// Token: 0x0603B5B0 RID: 243120 RVA: 0x00F08D18 File Offset: 0x00F06F18
		public void BindEntity(Entity entity, string actionName = null)
		{
			if (this.BoundEntity == entity)
			{
				return;
			}
			this.UnbindEntity();
			if (entity == null || !entity.Valid)
			{
				return;
			}
			this.BoundEntity = entity;
			Singleton<EventSystem>.Instance.AddWithTarget<float>(entity, EEventName.OnInteractionLongPressProgressChange, new Action<float>(this.OnInteractionLongPressProgressChange));
			UUITexture progressFill = this.ProgressFill;
			if (progressFill != null)
			{
				progressFill.SetFillAmount(0f);
			}
			this.RefreshKeyItem(actionName);
			this.SetActive(true);
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlaySequence("Start", false, null);
		}

		// Token: 0x0603B5B1 RID: 243121 RVA: 0x00F08DB0 File Offset: 0x00F06FB0
		private void RefreshKeyItem(string actionName)
		{
			if (this.KeyItem == null)
			{
				return;
			}
			string actionOrAxisName = actionName ?? "通用交互";
			this.KeyItem.RefreshByActionOrAxis(new InputActionOrAxisKeyItem
			{
				ActionOrAxisName = actionOrAxisName
			}, false);
			this.KeyItem.SetActive(true);
		}

		// Token: 0x0603B5B2 RID: 243122 RVA: 0x00F08DF8 File Offset: 0x00F06FF8
		public void UnbindEntity()
		{
			if (this.BoundEntity != null)
			{
				if (Singleton<EventSystem>.Instance.HasWithTarget(this.BoundEntity, EEventName.OnInteractionLongPressProgressChange, new Action<float>(this.OnInteractionLongPressProgressChange)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(this.BoundEntity, EEventName.OnInteractionLongPressProgressChange, new Action<float>(this.OnInteractionLongPressProgressChange));
				}
				this.BoundEntity = null;
			}
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.SetActive(false);
			}
			this.SetActive(false);
		}

		// Token: 0x0603B5B3 RID: 243123 RVA: 0x00F08E72 File Offset: 0x00F07072
		private void OnInteractionLongPressProgressChange(float progress)
		{
			UUITexture progressFill = this.ProgressFill;
			if (progressFill == null)
			{
				return;
			}
			progressFill.SetFillAmount(progress);
		}

		// Token: 0x0603B5B4 RID: 243124 RVA: 0x00F08E85 File Offset: 0x00F07085
		public void BindPress(Action<bool> callback)
		{
			this.OnPressCallback = callback;
		}

		// Token: 0x0603B5B5 RID: 243125 RVA: 0x00F08E90 File Offset: 0x00F07090
		private void OnButtonPointDown()
		{
			UUITexture progressFill = this.ProgressFill;
			if (progressFill != null)
			{
				progressFill.SetFillAmount(0f);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.WRY;
			string message = "[LongPressButton] OnButtonPointDown";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("hasCb", this.OnPressCallback != null);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Action<bool> onPressCallback = this.OnPressCallback;
			if (onPressCallback == null)
			{
				return;
			}
			onPressCallback(true);
		}

		// Token: 0x0603B5B6 RID: 243126 RVA: 0x00F08EFC File Offset: 0x00F070FC
		private void OnButtonPointUp()
		{
			UUITexture progressFill = this.ProgressFill;
			if (progressFill != null)
			{
				progressFill.SetFillAmount(0f);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.WRY;
			string message = "[LongPressButton] OnButtonPointUp";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("hasCb", this.OnPressCallback != null);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Action<bool> onPressCallback = this.OnPressCallback;
			if (onPressCallback == null)
			{
				return;
			}
			onPressCallback(false);
		}

		// Token: 0x0402172C RID: 137004
		private UUIButtonComponent Button;

		// Token: 0x0402172D RID: 137005
		private UUITexture ProgressFill;

		// Token: 0x0402172E RID: 137006
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0402172F RID: 137007
		private Action<bool> OnPressCallback;

		// Token: 0x04021730 RID: 137008
		private InputMultiKeyItem KeyItem;

		// Token: 0x04021731 RID: 137009
		private Entity BoundEntity;

		// Token: 0x04021732 RID: 137010
		private bool IsMobile;

		// Token: 0x0200BBDC RID: 48092
		[NullableContext(0)]
		private enum EChildTypeMobile
		{
			// Token: 0x04039F66 RID: 237414
			Button,
			// Token: 0x04039F67 RID: 237415
			ProgressFill,
			// Token: 0x04039F68 RID: 237416
			Icon,
			// Token: 0x04039F69 RID: 237417
			InfoPanel,
			// Token: 0x04039F6A RID: 237418
			TipsText
		}

		// Token: 0x0200BBDD RID: 48093
		[NullableContext(0)]
		private enum EChildTypePc
		{
			// Token: 0x04039F6C RID: 237420
			Button,
			// Token: 0x04039F6D RID: 237421
			ProgressFill,
			// Token: 0x04039F6E RID: 237422
			Icon,
			// Token: 0x04039F6F RID: 237423
			KeyItem,
			// Token: 0x04039F70 RID: 237424
			InfoPanel,
			// Token: 0x04039F71 RID: 237425
			TipsText
		}
	}
}
