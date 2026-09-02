using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui.Base
{
	// Token: 0x02004A66 RID: 19046
	[NullableContext(1)]
	[Nullable(0)]
	public static class UiComponentActionBinder
	{
		// Token: 0x06031BBB RID: 203707 RVA: 0x00C73E6F File Offset: 0x00C7206F
		private static bool TryGetCompatibleDelegate(int name, Delegate fn, [Nullable(2)] out Action callBack)
		{
			callBack = (fn as Action);
			if (callBack != null)
			{
				return true;
			}
			UiComponentActionBinder.ReportTypeMismatch(name, fn, typeof(Action));
			return false;
		}

		// Token: 0x06031BBC RID: 203708 RVA: 0x00C73E91 File Offset: 0x00C72091
		private static bool TryGetCompatibleDelegate<[Nullable(2)] T>(int name, Delegate fn, [Nullable(new byte[]
		{
			2,
			1
		})] out Action<T> callBack)
		{
			callBack = (fn as Action<T>);
			if (callBack != null)
			{
				return true;
			}
			UiComponentActionBinder.ReportTypeMismatch(name, fn, typeof(Action<T>));
			return false;
		}

		// Token: 0x06031BBD RID: 203709 RVA: 0x00C73EB4 File Offset: 0x00C720B4
		private static void ReportTypeMismatch(int componentName, Delegate actualDelegate, Type expectedDelegateType)
		{
			ParameterInfo[] parameters = actualDelegate.Method.GetParameters();
			MethodInfo method = expectedDelegateType.GetMethod("Invoke");
			ParameterInfo[] expectedParams = ((method != null) ? method.GetParameters() : null) ?? Array.Empty<ParameterInfo>();
			string message = UiComponentActionBinder.BuildTypeMismatchErrorMessage(componentName, actualDelegate.GetType(), parameters, expectedDelegateType, expectedParams);
			Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.LRX, message, default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06031BBE RID: 203710 RVA: 0x00C73F18 File Offset: 0x00C72118
		private static string BuildTypeMismatchErrorMessage(int componentName, Type actualType, ParameterInfo[] actualParams, Type expectedType, ParameterInfo[] expectedParams)
		{
			string parameterSignature = UiComponentActionBinder.GetParameterSignature(actualParams);
			string parameterSignature2 = UiComponentActionBinder.GetParameterSignature(expectedParams);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 5);
			defaultInterpolatedStringHandler.AppendLiteral("UI组件(#");
			defaultInterpolatedStringHandler.AppendFormatted<int>(componentName);
			defaultInterpolatedStringHandler.AppendLiteral(")委托类型不匹配 实际类型: ");
			defaultInterpolatedStringHandler.AppendFormatted(actualType.Name);
			defaultInterpolatedStringHandler.AppendLiteral("(");
			defaultInterpolatedStringHandler.AppendFormatted(parameterSignature);
			defaultInterpolatedStringHandler.AppendLiteral(") 期望类型: ");
			defaultInterpolatedStringHandler.AppendFormatted(expectedType.Name);
			defaultInterpolatedStringHandler.AppendLiteral("(");
			defaultInterpolatedStringHandler.AppendFormatted(parameterSignature2);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06031BBF RID: 203711 RVA: 0x00C73FC0 File Offset: 0x00C721C0
		private static string GetParameterSignature(ParameterInfo[] parameters)
		{
			if (parameters.Length == 0)
			{
				return "void";
			}
			string[] array = new string[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				array[i] = parameterInfo.ParameterType.Name + " " + parameterInfo.Name;
			}
			return string.Join(", ", array);
		}

		// Token: 0x06031BC0 RID: 203712 RVA: 0x00C7401C File Offset: 0x00C7221C
		private static string GetDelegateSignature(Type delegateType)
		{
			if (!typeof(Delegate).IsAssignableFrom(delegateType))
			{
				return delegateType.Name;
			}
			MethodInfo method = delegateType.GetMethod("Invoke");
			if (method == null)
			{
				return delegateType.Name;
			}
			ParameterInfo[] parameters = method.GetParameters();
			Type returnType = method.ReturnType;
			string parameterSignature = UiComponentActionBinder.GetParameterSignature(parameters);
			return ((returnType == typeof(void)) ? "void" : returnType.Name) + " (" + parameterSignature + ")";
		}

		// Token: 0x06031BC1 RID: 203713 RVA: 0x00C740A2 File Offset: 0x00C722A2
		private static string GetDelegateSignature(Delegate del)
		{
			return UiComponentActionBinder.GetDelegateSignature(del.GetType());
		}

		// Token: 0x06031BC2 RID: 203714 RVA: 0x00C740B0 File Offset: 0x00C722B0
		public static bool BindClickEvent(int name, UUIButtonComponent component, Delegate fn)
		{
			Action callback;
			if (!UiComponentActionBinder.TryGetCompatibleDelegate(name, fn, out callback))
			{
				return false;
			}
			component.OnClickCallBack.Bind(callback);
			return true;
		}

		// Token: 0x06031BC3 RID: 203715 RVA: 0x00C740D8 File Offset: 0x00C722D8
		public static bool BindClickEvent(int name, UUIToggleComponent component, Delegate fn)
		{
			Action<bool> callback;
			if (!UiComponentActionBinder.TryGetCompatibleDelegate<bool>(name, fn, out callback))
			{
				return false;
			}
			component.OnToggleEvent.Bind(callback);
			return true;
		}

		// Token: 0x06031BC4 RID: 203716 RVA: 0x00C74100 File Offset: 0x00C72300
		public static bool BindClickEvent(int name, UUIExtendToggle component, Delegate fn)
		{
			Action<EToggleState> callback;
			if (!UiComponentActionBinder.TryGetCompatibleDelegate<EToggleState>(name, fn, out callback))
			{
				return false;
			}
			component.OnStateChange.Add(callback);
			return true;
		}

		// Token: 0x06031BC5 RID: 203717 RVA: 0x00C74128 File Offset: 0x00C72328
		public static bool BindClickEvent(int name, UUISliderComponent component, Delegate fn)
		{
			Action<float> callback;
			if (!UiComponentActionBinder.TryGetCompatibleDelegate<float>(name, fn, out callback))
			{
				return false;
			}
			component.OnValueChangeCb.Bind(callback);
			return true;
		}

		// Token: 0x06031BC6 RID: 203718 RVA: 0x00C74150 File Offset: 0x00C72350
		public static bool BindClickEvent(int name, UUITextInputComponent component, Delegate fn)
		{
			Action<bool> callback;
			if (!UiComponentActionBinder.TryGetCompatibleDelegate<bool>(name, fn, out callback))
			{
				return false;
			}
			component.OnInputActivateDelegate.Bind(callback);
			return true;
		}
	}
}
