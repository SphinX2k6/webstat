using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.InputSetting;

namespace CSharpScript.Game.Controller
{
	// Token: 0x02007057 RID: 28759
	[NullableContext(1)]
	[Nullable(0)]
	public class CustomKeyActionData
	{
		// Token: 0x06045A24 RID: 285220 RVA: 0x0123220C File Offset: 0x0123040C
		public void SetCustomAction(string keyName, string actionName)
		{
			HashSet<string> hashSet;
			if (!this.CustomKeyActionMap.TryGetValue(keyName, out hashSet))
			{
				hashSet = new HashSet<string>();
				this.CustomKeyActionMap.Add(keyName, hashSet);
			}
			hashSet.Add(actionName);
		}

		// Token: 0x06045A25 RID: 285221 RVA: 0x01232244 File Offset: 0x01230444
		public void ResetAllCustomAction(string keyName)
		{
			this.CustomKeyActionMap.Remove(keyName);
		}

		// Token: 0x06045A26 RID: 285222 RVA: 0x01232254 File Offset: 0x01230454
		public void ResetCustomAction(string keyName, string actionName)
		{
			HashSet<string> hashSet;
			if (!this.CustomKeyActionMap.TryGetValue(keyName, out hashSet))
			{
				return;
			}
			hashSet.Remove(actionName);
		}

		// Token: 0x06045A27 RID: 285223 RVA: 0x0123227C File Offset: 0x0123047C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlySet<string> GetCustomActionName(string keyName)
		{
			if (this.CacheReasonSet.Count > 0)
			{
				return null;
			}
			HashSet<string> result;
			if (!this.CustomKeyActionMap.TryGetValue(keyName, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06045A28 RID: 285224 RVA: 0x012322AC File Offset: 0x012304AC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> GetCurrentPlatformCustomActionKeyNameList(string actionName)
		{
			if (this.CustomKeyActionMap == null)
			{
				return null;
			}
			bool flag = Singleton<Info>.Instance.IsInKeyBoard();
			bool flag2 = Singleton<Info>.Instance.IsInGamepad();
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, HashSet<string>> keyValuePair in this.CustomKeyActionMap)
			{
				string key = keyValuePair.Key;
				if (keyValuePair.Value.Contains(actionName))
				{
					if (flag && Singleton<InputSettings>.Instance.IsKeyboardKey(key))
					{
						list.Add(key);
					}
					else if (flag2 && Singleton<InputSettings>.Instance.IsGamepadKey(key))
					{
						list.Add(key);
					}
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return list;
		}

		// Token: 0x06045A29 RID: 285225 RVA: 0x01232378 File Offset: 0x01230578
		public void SetActionEnable(string actionName, bool bEnable)
		{
			if (bEnable)
			{
				this.DisableActionSet.Remove(actionName);
				return;
			}
			this.DisableActionSet.Add(actionName);
		}

		// Token: 0x06045A2A RID: 285226 RVA: 0x01232398 File Offset: 0x01230598
		public bool IsActionEnable(string actionName)
		{
			return this.CacheReasonSet.Count > 0 || !this.DisableActionSet.Contains(actionName);
		}

		// Token: 0x06045A2B RID: 285227 RVA: 0x012323BC File Offset: 0x012305BC
		public unsafe void DisableCustomInputData(string reason)
		{
			this.CacheReasonSet.Add(reason);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[CustomAction]临时禁用自定义输入数据";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CacheReasonSet", this.CacheReasonSet);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06045A2C RID: 285228 RVA: 0x01232430 File Offset: 0x01230630
		public unsafe void EnableCustomInputData(string reason)
		{
			this.CacheReasonSet.Remove(reason);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[CustomAction]恢复使用自定义输入数据";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CacheReasonSet", this.CacheReasonSet);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06045A2D RID: 285229 RVA: 0x012324A2 File Offset: 0x012306A2
		public void Clear()
		{
			this.CustomKeyActionMap.Clear();
			this.CacheReasonSet.Clear();
			this.DisableActionSet.Clear();
		}

		// Token: 0x04026DFC RID: 159228
		private readonly Dictionary<string, HashSet<string>> CustomKeyActionMap = new Dictionary<string, HashSet<string>>();

		// Token: 0x04026DFD RID: 159229
		private readonly HashSet<string> CacheReasonSet = new HashSet<string>();

		// Token: 0x04026DFE RID: 159230
		private readonly HashSet<string> DisableActionSet = new HashSet<string>();
	}
}
