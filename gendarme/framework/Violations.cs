//
// Gendarme.Framework.Violations class
//
// Authors:
//	Sebastien Pouliot <sebastien@ximian.com>
//	Christian Birkl <christian.birkl@gmail.com>
//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections;

namespace Gendarme.Framework {

	public class Violations : IEnumerable {

		private ArrayList list;

		internal Violations ()
		{
		}

		private IList List {
			get {
				if (list == null)
					list = new ArrayList ();
				return list;
			}
		}

		public int Count {
			get { return List.Count; }
		}
		
		public void Reset ()
		{
			list = null;
		}
		
		public void Add (IRule rule, object obj, IList messages)
		{
			if (rule == null)
				throw new ArgumentNullException ("rule");
			if (obj == null)
				throw new ArgumentNullException ("obj");

			List.Add (new Violation (rule, obj, messages));
		}

		public void Add (Violation v)
		{
			List.Add (v);
		}
		
		public IEnumerator GetEnumerator ()
		{
			return List.GetEnumerator();
		}
	}
}
