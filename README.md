            List<Task<Address>> addressTask = new List<Task<Address>>();
            addressTask.Add(Task.Factory.StartNew(() => _addressBuilder.BuildAddress("", "", "", "")));

            Task.WaitAll(addressTask.ToArray());
