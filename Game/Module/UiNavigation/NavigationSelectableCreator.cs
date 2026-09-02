using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CB4 RID: 19636
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationSelectableCreator : IStaticVariableResetter
	{
		// Token: 0x06033253 RID: 209491 RVA: 0x00CCE632 File Offset: 0x00CCC832
		static NavigationSelectableCreator()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(NavigationSelectableCreator.CreateStaticDefaultValue), new Action(NavigationSelectableCreator.ResetStaticDefaultValue));
		}

		// Token: 0x170087C1 RID: 34753
		// (get) Token: 0x06033254 RID: 209492 RVA: 0x00CCE651 File Offset: 0x00CCC851
		private static Dictionary<string, Type> NavigationBehaviorMap
		{
			get
			{
				return NavigationSelectableCreator._navigationBehaviorMap;
			}
		}

		// Token: 0x06033255 RID: 209493 RVA: 0x00CCE658 File Offset: 0x00CCC858
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private static ValueTuple<Type, string> GetBaseBehaviorCtorData(ULGUIBehaviour behavior)
		{
			ENavigationSelectableDefine enavigationSelectableDefine;
			if (behavior is UUIExtendToggle)
			{
				enavigationSelectableDefine = ENavigationSelectableDefine.Toggle;
			}
			else if (behavior is UUIButtonComponent)
			{
				enavigationSelectableDefine = ENavigationSelectableDefine.Button;
			}
			else if (behavior is UUIScrollViewWithScrollbarComponent)
			{
				enavigationSelectableDefine = ENavigationSelectableDefine.Scrollbar;
			}
			else if (behavior is UUISliderComponent)
			{
				enavigationSelectableDefine = ENavigationSelectableDefine.Slider;
			}
			else if (behavior is UUIDraggableComponent)
			{
				enavigationSelectableDefine = ENavigationSelectableDefine.DragComponent;
			}
			else
			{
				enavigationSelectableDefine = ENavigationSelectableDefine.Selectable;
			}
			return new ValueTuple<Type, string>(NavigationSelectableCreator.NavigationBehaviorMap[enavigationSelectableDefine.ToString()], enavigationSelectableDefine.ToString());
		}

		// Token: 0x06033256 RID: 209494 RVA: 0x00CCE6CC File Offset: 0x00CCC8CC
		[return: Nullable(2)]
		private unsafe static ULGUIBehaviour GetActorBehavior(AActor actor)
		{
			ULGUIBehaviour ulguibehaviour = actor.GetComponentByClass(UUISelectableComponent.StaticClass()) as UUISelectableComponent;
			if (ulguibehaviour == null)
			{
				ulguibehaviour = (actor.GetComponentByClass(UUIScrollViewComponent.StaticClass()) as UUIScrollViewComponent);
			}
			if (ulguibehaviour == null)
			{
				ulguibehaviour = (actor.GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent);
			}
			if (ulguibehaviour == null)
			{
				UUIItem uuiitem = actor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
				AUIBaseActor actor2 = ((uuiitem != null) ? uuiitem.GetOwner() : null) as AUIBaseActor;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.SYB;
				string message = "监听组件挂载节点获取不到交互组件";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("节点名", (uuiitem != null) ? uuiitem.displayName : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("节点路径", Singleton<LguiUtil>.Instance.GetActorFullPath(actor2));
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return ulguibehaviour;
		}

		// Token: 0x06033257 RID: 209495 RVA: 0x00CCE7BB File Offset: 0x00CCC9BB
		public static void RegisterNavigationBehavior(string type, Type ctor)
		{
			NavigationSelectableCreator.NavigationBehaviorMap[type] = ctor;
		}

		// Token: 0x06033258 RID: 209496 RVA: 0x00CCE7CC File Offset: 0x00CCC9CC
		[return: Nullable(2)]
		public static NavigationSelectableBase CreateNavigationBehavior([Nullable(2)] AActor actor, string tag, List<string> paramList)
		{
			if (actor == null)
			{
				return null;
			}
			ULGUIBehaviour actorBehavior = NavigationSelectableCreator.GetActorBehavior(actor);
			if (actorBehavior == null)
			{
				return null;
			}
			string text = tag;
			Type type;
			if (string.IsNullOrEmpty(tag) || !NavigationSelectableCreator.NavigationBehaviorMap.TryGetValue(tag, out type))
			{
				ValueTuple<Type, string> baseBehaviorCtorData = NavigationSelectableCreator.GetBaseBehaviorCtorData(actorBehavior);
				Type item = baseBehaviorCtorData.Item1;
				string item2 = baseBehaviorCtorData.Item2;
				type = item;
				text = item2;
			}
			return Activator.CreateInstance(type, new object[]
			{
				actorBehavior,
				text,
				paramList
			}) as NavigationSelectableBase;
		}

		// Token: 0x06033259 RID: 209497 RVA: 0x00CCE835 File Offset: 0x00CCCA35
		public static void CreateStaticDefaultValue()
		{
			NavigationSelectableCreator._navigationBehaviorMap = new Dictionary<string, Type>();
		}

		// Token: 0x0603325A RID: 209498 RVA: 0x00CCE841 File Offset: 0x00CCCA41
		public static void ResetStaticDefaultValue()
		{
			NavigationSelectableCreator._navigationBehaviorMap = null;
		}

		// Token: 0x0401DB87 RID: 121735
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<string, Type> _navigationBehaviorMap;
	}
}
