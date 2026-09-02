using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Module.Cursor
{
	// Token: 0x02005DEF RID: 24047
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class CursorController : UiControllerBase<CursorController>
	{
		// Token: 0x0603C816 RID: 247830 RVA: 0x00F5DACE File Offset: 0x00F5BCCE
		public void CursorEnterExit(bool isEnter)
		{
			this.EnterCurrentCursor(isEnter);
		}

		// Token: 0x0603C817 RID: 247831 RVA: 0x00F5DAD8 File Offset: 0x00F5BCD8
		private void EnterCurrentCursor(bool isEnter)
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return;
			}
			if (isEnter)
			{
				characterController.CurrentMouseCursor = EMouseCursor.CursorEnter;
				return;
			}
			characterController.CurrentMouseCursor = EMouseCursor.Default;
		}

		// Token: 0x0603C818 RID: 247832 RVA: 0x00F5DB0C File Offset: 0x00F5BD0C
		public unsafe void InitMouseByMousePos()
		{
			FVector2D slateApplicationCursorPos = UKuroStaticLibrary.GetSlateApplicationCursorPos();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiCommon;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "InitMouseByMousePos";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("viewPortMousePosition.X", slateApplicationCursorPos.X);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("viewPortMousePosition.Y", slateApplicationCursorPos.Y);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (slateApplicationCursorPos.X > 0f || slateApplicationCursorPos.Y > 0f)
			{
				Singleton<Log>.Instance.Info(ELogModule.UiCommon, ELogAuthor.YZY, "Mouse在屏幕内", default(ReadOnlySpan<ValueTuple<string, object>>));
				UKuroStaticLibrary.DoGameViewPortMouseEnter(UKuroStaticLibrary.GetGameViewPort(), (int)slateApplicationCursorPos.X, (int)slateApplicationCursorPos.Y);
			}
		}

		// Token: 0x0603C819 RID: 247833 RVA: 0x00F5DBD4 File Offset: 0x00F5BDD4
		public void SetWindowCursorStyle()
		{
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				string text;
				if (Singleton<Info>.Instance.IsPlayInEditor)
				{
					text = "Aki/UI/Module/Cursor/SourceResource";
				}
				else
				{
					text = "Aki/Cursor";
				}
				FName? dynamicFName = FNameUtil.GetDynamicFName(text + "/CursorNor");
				FName? dynamicFName2 = FNameUtil.GetDynamicFName(text + "/CursorHi");
				FName? dynamicFName3 = FNameUtil.GetDynamicFName(text + "/CursorPre");
				FVector2D hotSpot = new FVector2D(0f, 0f);
				UWorld world = GlobalData.World.GetWorld();
				UWidgetBlueprintLibrary.SetHardwareCursor(world, EMouseCursor.Default, dynamicFName.Value, hotSpot);
				UWidgetBlueprintLibrary.SetHardwareCursor(world, EMouseCursor.CursorEnter, dynamicFName2.Value, hotSpot);
				UWidgetBlueprintLibrary.SetHardwareCursor(world, EMouseCursor.CursorPress, dynamicFName3.Value, hotSpot);
				string cursor = UBlueprintPathsLibrary.ProjectContentDir() + "/" + text + "/CursorNor.png";
				ControllerBase<KuroSdkController>.Instance.SetCursor(cursor);
			}
		}
	}
}
